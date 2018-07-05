using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpClick : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public GameObject canvasObj;

    private void OnMouseDown() {
        
        // activate the canvas with the chamorro word text
        canvasObj = this.gameObject.transform.GetChild(0).gameObject;
        bool isActive = canvasObj.activeSelf;
        canvasObj.SetActive(!isActive);
    }
}