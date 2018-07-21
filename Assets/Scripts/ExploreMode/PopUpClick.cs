using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpClick : MonoBehaviour {

    void OnMouseDown()
    {
        ActivatePopUpCanvas();

        //Debug.Log(this.GetComponentInChildren<Text>().text);

        // this takes all but the last 2 characters of the object name
        string itemName = gameObject.name.Substring(0, gameObject.name.Length - 2);
        //string itemName = this.GetComponentInChildren<Text>().text;
        //Debug.Log(itemName);

        EventManager.TriggerEvent("popUp", itemName);
        //if(transform.Find("PopUp"))
        //{
        //    EventManager.TriggerEvent("popUp", this.GetComponentInChildren<Text>().text);
        //}
    }



    void ActivatePopUpCanvas()
    {
        GameObject canvasObj = this.gameObject.transform.Find("PopUp").gameObject;
        bool isActive = canvasObj.activeSelf;
        canvasObj.SetActive(!isActive);
    }

}