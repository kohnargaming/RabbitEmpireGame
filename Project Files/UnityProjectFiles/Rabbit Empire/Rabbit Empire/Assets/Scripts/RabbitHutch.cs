using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitHutch : MonoBehaviour
{
    // To-Do:
    // -Add functions for storing rabbits.

    public Transform cameraPos;
    public Canvas mainCanvas;
    Camera mainCam;

    private float progressToNewRabbit;
    private Text progressText;
    private Text rabbitCountText;

    private int rabbitsStored;
    private int buildingSize = 1;
    private int upgradeTier;
    public int maxRabbitStorage;

    public Transform spawnPosition;

    private void Awake()
    {
        mainCam = Camera.main;
        mainCanvas = transform.Find("Hutch Canvas").GetComponent<Canvas>();
        progressText = mainCanvas.transform.Find("ProgressCounter").GetComponentInChildren<Text>();
        rabbitCountText = mainCanvas.transform.Find("RabbitCount").GetComponentInChildren<Text>();

        mainCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        maxRabbitStorage = (5 * buildingSize) + upgradeTier;

        if (rabbitsStored != maxRabbitStorage)
        {
            progressText.transform.parent.gameObject.SetActive(true);
            progressToNewRabbit += 1.25f * Time.deltaTime;
            progressToNewRabbit = Mathf.Clamp(progressToNewRabbit, 0, 100);
        }
        else
        {
            progressText.transform.parent.gameObject.SetActive(false);
        }

        if (progressToNewRabbit == 100)
        {
            rabbitsStored += 1;
            progressToNewRabbit = 0;

            SpawnRabbit();
        }

        float e = Mathf.Round(progressToNewRabbit);
        rabbitsStored = Mathf.Clamp(rabbitsStored, 0, maxRabbitStorage);

        progressText.text = "Rabbit Breeding Progress: " + e.ToString() + "%";
        rabbitCountText.text = "Rabbits: " + rabbitsStored.ToString();
    }

    public void FocusOnHutch()
    {
        mainCam.transform.position = cameraPos.position;
        mainCam.transform.rotation = cameraPos.rotation;

        mainCanvas.gameObject.SetActive(true);
    }

    public void ExitHutchScreen()
    {
        CameraMovement cm = mainCam.GetComponent<CameraMovement>();
        cm.canRotate = true;

        mainCanvas.gameObject.SetActive(false);
    }

    public void SpeedUpRabbitGenProgress()
    {
        if (rabbitsStored != maxRabbitStorage)
            progressToNewRabbit += 2.5f;
    }

    private void SpawnRabbit()
    {
        RabbitPooler rabbitPooler = GameObject.Find("RabbitPooler").GetComponent<RabbitPooler>();
        rabbitPooler.SpawnFromPool("Rabbit", spawnPosition.position, Quaternion.identity);
    }
}