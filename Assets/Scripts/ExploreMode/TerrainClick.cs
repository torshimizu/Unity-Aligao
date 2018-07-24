using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainClick : MonoBehaviour
{
    public GameObject oceanPopUp;
    public GameObject terrainPopUp;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Vector3 mousePosition = Input.mousePosition;
            int oceanLayer = 1 << 4;
            int terrainLayer = 1 << 9;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out hit, 100, oceanLayer))
            {
                bool isActive = oceanPopUp.activeSelf;
                oceanPopUp.SetActive(!isActive);
                if (!isActive)
                {
                    Vector3 canvasPosition = new Vector3(hit.point.x, hit.point.y + 10.0f, hit.point.z);
                    oceanPopUp.transform.position = canvasPosition;
                    EventManager.TriggerEvent("popUp", "Ocean", "Tasi (ocean)");

                }
            }

            else if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out hit, 100, terrainLayer))
            {
                bool isActive = terrainPopUp.activeSelf;
                terrainPopUp.SetActive(!isActive);
                if (!isActive)
                {

                    Vector3 canvasPosition = new Vector3(hit.point.x, hit.point.y + 10.0f, hit.point.z);
                    terrainPopUp.transform.position = canvasPosition;
                    EventManager.TriggerEvent("popUp", "Sand", "Inai (sand)");

                }

            }
        }
    }
}
