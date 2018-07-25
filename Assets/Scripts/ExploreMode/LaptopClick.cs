using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopClick : MonoBehaviour {

	// Use this for initialization

	private void OnMouseDown()
	{
        ActivatePopUpCanvas();

	}

    void ActivatePopUpCanvas()
    {
        GameObject canvasObj = transform.Find("PopUp").gameObject;
        bool isActive = canvasObj.activeSelf;
        canvasObj.SetActive(!isActive);
    }
}
