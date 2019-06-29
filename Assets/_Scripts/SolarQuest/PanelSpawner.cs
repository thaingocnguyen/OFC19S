using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSpawner : MonoBehaviour
{
    
    [SerializeField] GameObject panel;


    private float dragDistance;
    private Vector3 panelPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        dragDistance = panel.GetComponent<DragAndBudget>().dragDistance;
        initialRotation = panel.transform.rotation;
    }

    void OnMouseDown()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragDistance);
        panelPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Instantiate(panel, panelPosition, initialRotation);
    }

}
