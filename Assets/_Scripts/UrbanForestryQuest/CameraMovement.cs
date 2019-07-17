using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LevelEditor
{
    public class CameraMovement : MonoBehaviour
    {
        // Target
        Transform target;
        Vector3 targetOffset;
        [SerializeField] float targetDistance = 5f;

        // Camera movement adjustment
        [SerializeField] float zoomRate = 10.0f;
        [SerializeField] float panSpeed = 0.3f;
        [SerializeField] float zoomDampening = 5.0f;

        // Boundary of camera
        [SerializeField] float leftEdge = 17f;
        [SerializeField] float rightEdge = 70f;
        [SerializeField] float yAxis = 10f;
        [SerializeField] float zAxis = -11f;

        private float xDeg = 0.0f;
        private float yDeg = 0.0f;
        private float currentDistance;
        private float desiredDistance;
        private Quaternion rotation;
        private Vector3 position;

        private Vector3 firstPos;
        private Vector3 secondPos;
        private Vector3 delta;
        private Vector3 lastOffset;

        private Vector3 origCameraPos;
        private Quaternion origCameraRot;

        void Start() { Init(); }
        void OnEnable() { Init(); }

        public void Init()
        {
            // Create a temporary target at 'distance' from the cameras current viewpoint
            GameObject go = new GameObject("Cam Target");
            go.transform.position = transform.position + (transform.forward * targetDistance);
            target = go.transform;

            targetDistance = Vector3.Distance(transform.position, target.position);
            currentDistance = targetDistance;
            desiredDistance = targetDistance;

            //Set current rotations as starting points.
            position = transform.position;
            rotation = transform.rotation;

            origCameraPos = transform.position;
            origCameraRot = transform.rotation;

            xDeg = Vector3.Angle(Vector3.right, transform.right);
            yDeg = Vector3.Angle(Vector3.up, transform.up);
        }


        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstPos = Input.mousePosition;
                lastOffset = targetOffset;
            }

            if (Input.GetMouseButton(0))
            {
                secondPos = Input.mousePosition;
                delta = secondPos - firstPos;
                targetOffset = lastOffset + transform.right * delta.x * panSpeed + transform.up * delta.y * panSpeed;
            }

            currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);

            position = target.position - (rotation * Vector3.forward * currentDistance);
            position = position - targetOffset;

            transform.position = new Vector3(
                Mathf.Clamp(position.x, leftEdge, rightEdge),
                Mathf.Clamp(position.y, yAxis, yAxis),
                Mathf.Clamp(position.z, zAxis, zAxis));

        }

        public void ResetCameraPosition()
        {
            transform.position = origCameraPos;
            transform.rotation = origCameraRot;
        }

    }


}

