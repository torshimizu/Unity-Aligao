using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpClick : MonoBehaviour {

    void OnMouseDown()
    {
        ActivatePopUpCanvas();

        if(this.GetComponentInChildren<Text>() != null){ // this still finds inactive game object

            // this takes all but the last 2 characters of the object name
            string itemName = gameObject.name.Substring(0, gameObject.name.Length - 2);
            string translation = this.GetComponentInChildren<Text>().text;
            //Debug.Log(itemName);

            EventManager.TriggerEvent("popUp", itemName, translation);
        }

        //Debug.Log(this.GetComponentInChildren<Text>().text);
    }


    void ActivatePopUpCanvas()
    {
        GameObject canvasObj = transform.Find("PopUp").gameObject;
        bool isActive = canvasObj.activeSelf;
        canvasObj.SetActive(!isActive);
    }

}