using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private int gridRows;
    [SerializeField]
    private int gridCols;

    Vector3 gizmoPos;

    private void Start()
    {
         
    }

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.matrix = transform.localToWorldMatrix;
        gizmoPos = gameObject.transform.position;
        for (float x = gizmoPos.x; x < gizmoPos.x + gridCols; x += size)
        {
            for (float z = gizmoPos.z; z < gizmoPos.z + gridRows; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, gizmoPos.y, z));
                Gizmos.DrawSphere(point, 0.1f);
            }

        }

    }
}
