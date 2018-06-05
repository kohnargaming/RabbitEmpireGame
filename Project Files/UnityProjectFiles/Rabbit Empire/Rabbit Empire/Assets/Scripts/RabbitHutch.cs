using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitHutch : MonoBehaviour
{
    public Transform cameraPos;
    public Canvas mainCanvas;
    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    public void FocusOnHutch()
    {
        mainCam.transform.position = cameraPos.position;
        mainCam.transform.rotation = cameraPos.rotation;

        mainCanvas.gameObject.SetActive(true);
    }
}