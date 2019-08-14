﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
{
    public class DragTrees : MonoBehaviour
    {
        Node initialNode;
        Vector3 mousePosition;
        Vector3 worldPosition;
        Node curNode;
        Level_Object currentTreeProperties;
        public GameObject cameraControllerObj;

        GridBase gridBase;

        // Start is called before the first frame update
        void Start()
        {
            gridBase = GridBase.GetInstance();
        }

        void OnMouseDown()
        {
            CameraController.GetInstance().MovementEnabled = false;
            curNode = GridBase.GetInstance().NodeFromWorldPosition(mousePosition);
            currentTreeProperties = GetComponent<Level_Object>();
            initialNode = gridBase.grid[currentTreeProperties.gridPosX, currentTreeProperties.gridPosZ];
        }

        void OnMouseDrag()
        {
            UpdateMousePosition();
            curNode = GridBase.GetInstance().NodeFromWorldPosition(mousePosition);
            worldPosition = curNode.vis.transform.position;
            transform.position = worldPosition;
        }

        void OnMouseUp()
        {
            if (curNode.placedObj != null)
            {
                transform.position = initialNode.vis.transform.position;
            }
            else
            {
                initialNode.placedObj = null;
                currentTreeProperties.gridPosX = curNode.nodePosX;
                currentTreeProperties.gridPosZ = curNode.nodePosZ;
                LevelManager.GetInstance().UpdateCanopyScore();
                curNode.placedObj = currentTreeProperties;
            }

            CameraController.GetInstance().MovementEnabled = false;
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
    }
}

