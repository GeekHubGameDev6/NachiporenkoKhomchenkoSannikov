﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTriggerDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
       // var todestract = other.gameObject;
        Destroy(other.gameObject);
    }
}
