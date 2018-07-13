﻿using UnityEngine;
using System.Collections;

public class PopUpClick : MonoBehaviour {

    void OnMouseDown()
    {
        ActivatePopUpCanvas();

        // this takes all but the last 2 characters of the object name
        string itemName = gameObject.name.Substring(0, gameObject.name.Length - 2);

        EventManager.TriggerEvent("popUp", itemName);
    }



    void ActivatePopUpCanvas()
    {
        GameObject canvasObj = this.gameObject.transform.Find("PopUp").gameObject;
        bool isActive = canvasObj.activeSelf;
        canvasObj.SetActive(!isActive);
    }

}