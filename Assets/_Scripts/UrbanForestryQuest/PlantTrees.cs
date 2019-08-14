using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
{
    public class PlantTrees : MonoBehaviour
    {
        LevelManager levelManager;
        GridBase gridBase;
        InterfaceManager ui;
        UISpace uiSpace;
        BudgetManager budgetManger;

        bool placeModeOn;
        public bool deleteModeOn;
        bool objMoving;
        GameObject currentObject;
        Node curNode;

        // Place obj variables
        GameObject objToPlace;
        GameObject cloneObj;
        Level_Object objProperties;
        Vector3 mousePosition;
        Vector3 worldPosition;

        // Tile painting
        bool paintTile;
        public Material matToPlace;
        Material origMaterial;
        int multiplier;
        
        Quaternion targetRot;

        [SerializeField] GameObject placeButton;
        [SerializeField] GameObject deleteButton;

        [SerializeField] GameObject cameraControllerObj;
        CameraController cameraController;

        public GameObject smallTree;

        GameObject currentTree;
        Level_Object currentTreeProperties;

        private void Start()
        {
            gridBase = GridBase.GetInstance();
            levelManager = LevelManager.GetInstance();
            budgetManger = BudgetManager.GetInstance();
            ui = InterfaceManager.GetInstance();
            uiSpace = UISpace.GetInstance();

            cameraController = cameraControllerObj.GetComponent<CameraController>();
        }

        private void Update()
        {
            //PlaceObject();
            //DeleteObjects();
            //PaintTile();
        }

        void UpdateMousePosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                mousePosition = hit.point;
            }
        }

        public void CloseAllModes()
        {
            if (deleteModeOn)
            {
                DeleteModeToggle();
            }

            if (placeModeOn)
            {
                PlaceModeToggle();
            }
        }

        // Toggle the ability to place trees on/off
        public void PlaceModeToggle()
        {
            if (deleteModeOn)
            {
                DeleteModeToggle();
            }
            if (!placeModeOn)
            {
                placeModeOn = true;
                placeButton.GetComponent<ButtonToggle>().On = true;
                objToPlace = ResourceManager.GetInstance().GetObjBase("tree_small").objPrefab;

                cameraController.MovementEnabled = false;
            }
            else
            {
                placeModeOn = false;
                placeButton.GetComponent<ButtonToggle>().On = false;

                // If there is a tree placed
                if (cloneObj != null)
                {
                    // Add to scene object list
                    levelManager.inSceneGameObjects.Add(cloneObj);
                    budgetManger.DecrementBudget();
                    // Update the score
                    levelManager.UpdateCanopyScore();
                    curNode.placedObj = objProperties;
                    cloneObj = null;
                }
                curNode = null;

                cameraController.MovementEnabled = true;
            }
        }

        // Toggle the ability to delete trees on/off
        public void DeleteModeToggle()
        {
            if (placeModeOn)
            {
                PlaceModeToggle();
            }
            if (!deleteModeOn)
            {
                deleteModeOn = true;
                deleteButton.GetComponent<ButtonToggle>().On = true;

                cameraController.MovementEnabled = false;
            }
            else
            {
                deleteModeOn = false;
                deleteButton.GetComponent<ButtonToggle>().On = false;
                levelManager.UpdateCanopyScore();

                cameraController.MovementEnabled = true;
            }
        }

        #region Place Objects
        public void BeginTreeDrag()
        {
            cameraController.MovementEnabled = false;
            Debug.Log("Begin drag");
            UpdateMousePosition();
            curNode = gridBase.NodeFromWorldPosition(mousePosition);
            worldPosition = curNode.vis.transform.position;

            // If object hasn't been instantiated then instantiate it
            if (currentTree == null)
            {
                currentTree = Instantiate(smallTree, worldPosition, Quaternion.identity) as GameObject;
                currentTreeProperties = currentTree.GetComponent<Level_Object>();
            }
        }

        public void DuringTreeDrag()
        {
            UpdateMousePosition();
            curNode = gridBase.NodeFromWorldPosition(mousePosition);
            worldPosition = curNode.vis.transform.position;
            currentTree.transform.position = worldPosition;
        }

        public void EndTreeDrag()
        {
            Debug.Log("End drag");
            if (curNode.placedObj != null)
            {
                Destroy(currentTree);
                currentTree = null;
                currentTreeProperties = null;
            }
            else
            {
                currentTreeProperties.gridPosX = curNode.nodePosX;
                currentTreeProperties.gridPosZ = curNode.nodePosZ;
                levelManager.inSceneGameObjects.Add(currentTree);

                budgetManger.DecrementBudget();
                levelManager.UpdateCanopyScore();

                curNode.placedObj = currentTreeProperties;
                currentTree = null;
            }

            cameraController.MovementEnabled = true;
        }


        void PlaceObject()
        {
            if (placeModeOn)
            {
                // When mouse is held down
                if (Input.GetMouseButton(0) && !uiSpace.IsPointerOverGameObject())
                {
                    // Get node on grid from mouse position
                    UpdateMousePosition();
                    curNode = gridBase.NodeFromWorldPosition(mousePosition);
                    worldPosition = curNode.vis.transform.position;

                    // If object hasn't been instantiated then instantiate it
                    if (cloneObj == null)
                    {
                        cloneObj = Instantiate(objToPlace, worldPosition, Quaternion.identity) as GameObject;
                        objProperties = cloneObj.GetComponent<Level_Object>();
                    }
                    // Else change position of object to mouse position
                    else
                    {
                        cloneObj.transform.position = worldPosition;
                    }
                }
                // When mouse is released and there is a clone object 
                if (Input.GetMouseButtonUp(0) && cloneObj != null && !uiSpace.IsPointerOverGameObject())
                {
                    // If current node have a placed object remove clone object, do not allow object to be placed
                    if (curNode.placedObj != null)
                    {
                        // Remove clone object
                        Destroy(cloneObj);
                        cloneObj = null;
                        objProperties = null;
                    }
                    else
                    {
                        objProperties.gridPosX = curNode.nodePosX;
                        objProperties.gridPosZ = curNode.nodePosZ;
                    }
                }

            }
        }


        void DeleteObjects()
        {
            if (deleteModeOn)
            {
                UpdateMousePosition();
                curNode = gridBase.NodeFromWorldPosition(mousePosition);

                if (Input.GetMouseButtonDown(0) && !ui.mouseOverUIElement)
                {
                    if (curNode.placedObj != null)
                    {
                        if (levelManager.inSceneGameObjects.Contains(curNode.placedObj.gameObject))
                        {
                            levelManager.inSceneGameObjects.Remove(curNode.placedObj.gameObject);
                            budgetManger.IncrementBudget();
                            Destroy(curNode.placedObj.gameObject);
                        }

                        curNode.placedObj = null;
                    }
                }
            }
        }

        #endregion

        #region Tile Painting
        bool paintOn = false;
        public void TogglePaintTile()
        {
            if (!paintOn)
            {
                paintOn = true;
                matToPlace = ResourceManager.GetInstance().GetMaterial(1);
                multiplier = MultiplierFromMatId(1);
            }
            else
            {
                paintOn = false;
            }
        }
        void PaintTile()
        {
            if (paintOn)
            {
                UpdateMousePosition();

                Node newNode = gridBase.NodeFromWorldPosition(mousePosition);

                if (Input.GetMouseButtonDown(0) && !uiSpace.IsPointerOverGameObject())
                {
                    newNode.tileRenderer.material = matToPlace;
                    newNode.vis.transform.localRotation = targetRot;
                    int matId = ResourceManager.GetInstance().GetMaterialId(matToPlace);
                    NodeObject nodeObj = newNode.vis.GetComponent<NodeObject>();
                    nodeObj.textureId = matId;
                    nodeObj.multiplier = multiplier;
                }
                else if (Input.GetMouseButtonDown(1) && !uiSpace.IsPointerOverGameObject())
                {
                    origMaterial = ResourceManager.GetInstance().GetMaterial(0);
                    newNode.tileRenderer.material = origMaterial;
                    newNode.vis.transform.localRotation = targetRot;
                    NodeObject nodeObj = newNode.vis.GetComponent<NodeObject>();
                    nodeObj.textureId = 0;
                    nodeObj.multiplier = 1;
                }
            }
        }

        public void PassMaterialToPaint(int matId)
        {
            matToPlace = ResourceManager.GetInstance().GetMaterial(matId);
            multiplier = MultiplierFromMatId(matId);
        }

        private int MultiplierFromMatId(int matId)
        {
            int multi;
            switch (matId)
            {
                case 0:
                    multi = 1;
                    break;
                case 1:
                    multi = 0;
                    break;
                default:
                    multi = 1;
                    break;
            }
            return multi;
        }
        #endregion

    }
}

