﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController2 : MonoBehaviour {

	public float speed = 20.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0, 0, speed * Time.deltaTime);
	}
}
