using UnityEngine;
using System.Collections;

public class PopUpClick : MonoBehaviour {

    void OnMouseDown()
    {
        
        GameObject canvasObj = this.gameObject.transform.Find("PopUp").gameObject;
        bool isActive = canvasObj.activeSelf;
        canvasObj.SetActive(!isActive);

        EventManager.TriggerEvent("popUp", gameObject.name);
    }

}