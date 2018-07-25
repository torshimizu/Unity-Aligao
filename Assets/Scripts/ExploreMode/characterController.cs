using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

    public float moveSpeed = 50f;
    public float turnSpeed = 60f;

	
	void Update () {
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)){
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)){
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);         
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);         
        }
        if (Input.GetKey(KeyCode.D)){
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);         
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);         
        }

	}

}
