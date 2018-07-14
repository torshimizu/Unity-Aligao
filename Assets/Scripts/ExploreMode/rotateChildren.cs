using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateChildren : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(0, 30 * Time.deltaTime, 0);
        if (GameObject.FindWithTag("prop"))
        {
            GameObject.FindWithTag("prop").transform.Rotate(0, 30 * Time.deltaTime, 0);
        }
	}
}
