﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpRotation : MonoBehaviour {
    public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = player.rotation;
	}
}
