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

        // paint tile variables
        bool hasMaterial;
        bool paintTile;
        public Material matToPlace;
        Node previousNode;
        Material prevMaterial;
        Quaternion targetRot;
        Quaternion prevRotation;

        // Place stack objs variables 
        bool placeStackObj;
        GameObject stackObjToPlace;
        GameObject stackCloneObj;
        Level_Object stackObjProperties;
        bool deleteStackObj;

        // Wall creator variables
        bool createWall;
        public GameObject wallPrefab;
        Node startNode_Wall;
        Node endNodeWall;
        public Material[] wallPlacementMat;
        bool deleteWall;

        private void Start()
        {
            gridBase = GridBase.GetInstance();
            manager = LevelManager.GetInstance();
            ui = InterfaceManager.GetInstance();

            //PaintAll();
        }

        private void Update()
        {
            PlaceObject();
            DeleteObjs();
            //PaintTile();
            //PlaceStackedObj();
            //CreateWall();
            //DeleteStackedObjs();
            //DeleteWallsActual();
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
            if (!placeModeOn)
            {
                placeModeOn = true;
                PassGameObjectToPlace("tree_small");
            }
            else
            {
                placeModeOn = false;
                if (cloneObj != null)
                {
                    Debug.Log("Saved tree");
                    manager.inSceneGameObjects.Add(cloneObj);
                    cloneObj = null;
                }
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


        public void PassGameObjectToPlace(string objId)
        {
            if (cloneObj != null)
            {
                Destroy(cloneObj);
            }

            CloseAll();
            hasObj = true;
            cloneObj = null;
            objToPlace = ResourceManager.GetInstance().GetObjBase(objId).objPrefab;
        }



        void DeleteObjs()
        {
            if (deleteObj)
            {
                UpdateMousePosition();

                Node curNode = gridBase.NodeFromWorldPosition(mousePosition);

                if (Input.GetMouseButton(0) && !ui.mouseOverUIElement)
                {
                    if (curNode.placedObj != null)
                    {
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

        void DeleteObj()
        {
            CloseAll();
            deleteObj = true;
        }
        #endregion

        void CloseAll()
        {
            hasObj = false;
            deleteObj = false;
            paintTile = false;
            placeStackObj = false;
            createWall = false;
            hasMaterial = false;
            deleteStackObj = false;
            deleteWall = false;
        }
    }
}

