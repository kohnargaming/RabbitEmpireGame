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
            // Camera movement is managed by other functions.
            // Camera movement functions can be mapped to UI Buttons for
            // mobile version.
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                TurnUp();
            else if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
                TurnDown();

            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                TurnRight();
            else if (!Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
                TurnLeft();

            cameraYRotation = Mathf.Clamp(cameraYRotation, 5, 75);

            cameraPosZ -= Input.GetAxis("Mouse ScrollWheel") * sensitivity * 10;
            cameraPosZ = Mathf.Clamp(cameraPosZ, 10, 60);

            Vector3 cameraDirection = new Vector3(0, 0, -cameraPosZ);
            Quaternion cameraRotation = Quaternion.Euler(cameraYRotation, cameraXRotation, 0);
            transform.position = cameraAnchor + cameraRotation * cameraDirection;

            transform.LookAt(cameraAnchor);
        }
    }

    public void TurnLeft()
    {
        cameraXRotation += 1 * sensitivity;
    }

    public void TurnRight()
    {
        cameraXRotation -= 1 * sensitivity;
    }

    public void TurnUp()
    {
        cameraYRotation += 1 * sensitivity;
    }

    public void TurnDown()
    {
        cameraYRotation -= 1 * sensitivity;
    }
}