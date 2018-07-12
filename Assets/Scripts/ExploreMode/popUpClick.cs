using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpClick : MonoBehaviour {

    delegate void MultiDelegate();
    MultiDelegate clickDelegate;

    // Use this for initialization
    void Start() 
    {
        clickDelegate += OnMouseDown;
        clickDelegate += AddObjectToFoundList;
    }


    private void OnMouseDown() 
    {
        clickDelegate();
    }

    private void ActivatePopUp() 
    {
        // activate the canvas with the chamorro word text
        GameObject canvasObj = this.gameObject.transform.Find("PopUp").gameObject;
        bool isActive = canvasObj.activeSelf;
        canvasObj.SetActive(!isActive);
    }

    private void AddObjectToFoundList() {
        // this will add object to a List in GameControl;
        Debug.Log("AddObjectToFoundList has been called");
    }
}