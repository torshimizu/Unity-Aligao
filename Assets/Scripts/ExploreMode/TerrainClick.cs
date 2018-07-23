using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainClick : MonoBehaviour
{
    public GameObject popUp;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Vector3 mousePosition = Input.mousePosition;


            if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out hit, 100))
            {
                if (hit.transform.name == "Terrain" || hit.transform.name == "Water4Simple")
                {
                    string nameToSend = hit.transform.name == "Terrain" ? "Sand" : "Ocean";
                    bool isActive = popUp.activeSelf;
                    popUp.SetActive(!isActive);
                    if (!isActive)
                    {
                        string translation = this.GetComponentInChildren<Text>().text;

                        Vector3 canvasPosition = new Vector3(hit.point.x, hit.point.y + 8.0f, hit.point.z);
                        popUp.transform.position = canvasPosition;
                        EventManager.TriggerEvent("popUp", nameToSend, translation);
                    }
                }

            }
        }
    }
}
