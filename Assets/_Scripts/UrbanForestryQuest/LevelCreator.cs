using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
    public class LevelCreator : MonoBehaviour
    {
        LevelManager manager;
        GridBase gridBase;
        InterfaceManager ui;

        bool placeModeOn;
        bool deleteModeOn;
        bool objMoving;
        GameObject currentObject;
        Node curNode;

        // Place obj variables
        bool hasObj;
        GameObject objToPlace;
        GameObject cloneObj;
        Level_Object objProperties;
        Vector3 mousePosition;
        Vector3 worldPosition;
        bool deleteObj;

        [SerializeField] GameObject placeButton;
        [SerializeField] GameObject deleteButton;

        private void Start()
        {
            gridBase = GridBase.GetInstance();
            manager = LevelManager.GetInstance();
            ui = InterfaceManager.GetInstance();
        }

        private void Update()
        {
            PlaceObject();
            DeleteObjects();
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
            }
            else
            {
                placeModeOn = false;
                placeButton.GetComponent<ButtonToggle>().On = false;

                // If there is a tree placed
                if (cloneObj != null)
                {
                    // Add to scene object list
                    manager.inSceneGameObjects.Add(cloneObj);
                    // Update the score
                    manager.UpdateCanopyScore();
                    curNode.placedObj = objProperties;
                    cloneObj = null;
                }
                curNode = null;
            }
        }

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
            }
            else
            {
                deleteModeOn = false;
                deleteButton.GetComponent<ButtonToggle>().On = false;
            }
        }

        #region Place Objects
        //void PlaceObject()
        //{
        //    if (hasObj)
        //    {
        //        UpdateMousePosition();

        //        Node curNode = gridBase.NodeFromWorldPosition(mousePosition);

        //        worldPosition = curNode.vis.transform.position;

        //        if (cloneObj == null)
        //        {
        //            cloneObj = Instantiate(objToPlace, worldPosition, Quaternion.identity) as GameObject;
        //            objProperties = cloneObj.GetComponent<Level_Object>();
        //        }
        //        else
        //        {
        //            cloneObj.transform.position = worldPosition;

        //            // Placing object
        //            if (Input.GetMouseButton(0) && !ui.mouseOverUIElement)
        //            {
        //                // If current node have a placed object
        //                if (curNode.placedObj != null)
        //                {
        //                    manager.inSceneGameObjects.Remove(curNode.placedObj.gameObject);
        //                    Destroy(curNode.placedObj.gameObject);
        //                    curNode.placedObj = null;
        //                }

        //                GameObject actualObjPlaced = Instantiate(objToPlace, worldPosition, cloneObj.transform.rotation) as GameObject;
        //                Level_Object placedObjProperties = actualObjPlaced.GetComponent<Level_Object>();

        //                placedObjProperties.gridPosX = curNode.nodePosX;
        //                placedObjProperties.gridPosZ = curNode.nodePosZ;
        //                curNode.placedObj = placedObjProperties;
        //                manager.inSceneGameObjects.Add(actualObjPlaced);
        //            }

        //            if (Input.GetMouseButtonUp(1))
        //            {
        //                objProperties.ChangeRotation();
        //            }
        //        }
        //    }
        //}

        void PlaceObject()
        {
            if (placeModeOn)
            {
                // When mouse is held down
                if (Input.GetMouseButton(0) && !ui.mouseOverUIElement)
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
                if (Input.GetMouseButtonUp(0) && cloneObj != null && !ui.mouseOverUIElement)
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


        //public void PassGameObjectToPlace(string objId)
        //{
        //    if (cloneObj != null)
        //    {
        //        Destroy(cloneObj);
        //    }

        //    CloseAll();
        //    hasObj = true;
        //    cloneObj = null;
        //    objToPlace = ResourceManager.GetInstance().GetObjBase(objId).objPrefab;
        //}



        void DeleteObjects()
        {
            if (deleteModeOn)
            {
                UpdateMousePosition();
                curNode = gridBase.NodeFromWorldPosition(mousePosition);

                if (Input.GetMouseButton(0) && !ui.mouseOverUIElement)
                {
                    //Debug.Log("X: " + curNode.nodePosX);
                    //Debug.Log("Z: " + curNode.nodePosZ);
                    if (curNode.placedObj != null)
                    {
                        Debug.Log("Has tree");
                        if (manager.inSceneGameObjects.Contains(curNode.placedObj.gameObject))
                        {
                            manager.inSceneGameObjects.Remove(curNode.placedObj.gameObject);
                            Destroy(curNode.placedObj.gameObject);
                        }

                        curNode.placedObj = null;
                    }
                }
            }
        }

        #endregion

        void CloseAll()
        {
            hasObj = false;
            deleteObj = false;
        }
    }
}

