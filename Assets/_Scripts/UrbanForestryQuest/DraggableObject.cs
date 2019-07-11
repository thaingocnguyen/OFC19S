using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
    public class DraggableObject : MonoBehaviour
    {
        Vector3 initialPosition;
        Quaternion initialRotation;
        Vector3 mousePosition;
        Vector3 worldPosition;

        Level_Object objProperties;
        GameObject cloneObj;
        Node curNode;

        GridBase gridBase;
        LevelManager manager;

        bool placed;
        [SerializeField] GameObject objectToInstantiate;

        private void Start()
        {
            manager = LevelManager.GetInstance();
            placed = false;
            initialPosition = gameObject.transform.position;
            initialRotation = gameObject.transform.rotation;
        }

        void OnMouseDown()
        {
            if (!placed)
            {
                cloneObj = Instantiate(objectToInstantiate, initialPosition, initialRotation);
            }
            else
            {
                cloneObj = gameObject;
            }
            
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

        void OnMouseDrag()
        {
            UpdateMousePosition();
            curNode = GridBase.GetInstance().NodeFromWorldPosition(mousePosition);
            worldPosition = curNode.vis.transform.position;
            cloneObj.transform.position = worldPosition;
        }

        void OnMouseUp()
        {
            if (curNode.placedObj != null)
            {
                manager.inSceneGameObjects.Remove(curNode.placedObj.gameObject);
                Destroy(curNode.placedObj.gameObject);
                curNode.placedObj = null;
            }

            curNode.placedObj = cloneObj.GetComponent<Level_Object>();
            manager.inSceneGameObjects.Add(cloneObj);
            placed = true;
        }

    }
}

