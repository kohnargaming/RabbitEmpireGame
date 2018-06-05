using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInteraction : MonoBehaviour
{
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.transform.name == "Rabbit Hutch")
                {
                    print("Moving Cam");
                    CameraMovement cm = GetComponent<CameraMovement>();
                    cm.canRotate = false;
                    RabbitHutch rh = hit.transform.GetComponent<RabbitHutch>();
                    rh.FocusOnHutch();
                }
            }
        }
    }
}