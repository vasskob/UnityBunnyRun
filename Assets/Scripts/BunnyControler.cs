﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyControler : MonoBehaviour {
	private Rigidbody2D myRigidbody;
	public float bunnyJumpForce=500f;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Jump")) {
			myRigidbody.AddForce (transform.up * bunnyJumpForce);
		}
	}
}