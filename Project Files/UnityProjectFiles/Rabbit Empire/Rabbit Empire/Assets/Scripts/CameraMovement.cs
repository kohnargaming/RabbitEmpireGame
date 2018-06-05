using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool canRotate = true;

    public float sensitivity = 2;

    private float cameraXRotation = 90;
    private float cameraYRotation = 35;

    private float cameraAnchorX;
    private float cameraAnchorZ;

    private float cameraPosZ = 60;

    private Vector3 cameraAnchor;

    private void Awake()
    {
        cameraAnchor = Vector3.zero;
    }

    private void Update()
    {
        if (canRotate)
        {
            cameraXRotation -= Input.GetAxis("Horizontal") * sensitivity;
            cameraYRotation += Input.GetAxis("Vertical") * sensitivity;
            cameraYRotation = Mathf.Clamp(cameraYRotation, 5, 75);

            cameraPosZ -= Input.GetAxis("Mouse ScrollWheel") * sensitivity * 10;
            cameraPosZ = Mathf.Clamp(cameraPosZ, 10, 60);

            Vector3 cameraDirection = new Vector3(0, 0, -cameraPosZ);
            Quaternion cameraRotation = Quaternion.Euler(cameraYRotation, cameraXRotation, 0);
            transform.position = cameraAnchor + cameraRotation * cameraDirection;

            transform.LookAt(cameraAnchor);
        }
    }
}