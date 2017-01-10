﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BunnyControler : MonoBehaviour {
	private Rigidbody2D myRigidbody;
	private Animator myAnim;
	public float bunnyJumpForce=500f;
	private float bunnyHurtTime = -1;
	private Collider2D myCollider;
	public Text scoreTxt;
	private float startTime;
	private int jumpsCount=2;
	public AudioSource jumpSfx;
	public AudioSource deathSfx;



	// Use this for initialization

	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator> ();
		myCollider = GetComponent<Collider2D>();

		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (bunnyHurtTime == -1) {
			if (Input.GetButtonUp ("Jump") && jumpsCount>0) {

				if (myRigidbody.velocity.y < 0) {
					myRigidbody.velocity = Vector2.zero;
				}
				if (jumpsCount == 1) {
					myRigidbody.AddForce (transform.up * bunnyJumpForce*0.75f);
				} else {
					myRigidbody.AddForce (transform.up * bunnyJumpForce);
				}
				jumpsCount--;
				jumpSfx.Play();
				// myRigidbody.AddForceAtPosition (transform.);
			}
			//	myAnim.SetFloat ("wVelocity", Mathf.Abs(myRigidbody.velocity.y));
			myAnim.SetFloat ("wVelocity", myRigidbody.velocity.y);
			scoreTxt.text = (Time.time - startTime).ToString("0.0");
		} else {
			if (Time.time > bunnyHurtTime + 2) {
				SceneManager.LoadScene ("maneScene");
			}
		}
	}
	void OnCollisionEnter2D (Collision2D collision){
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {

			foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>()) {
				spawner.enabled = false;
			}

			foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>()) {
				moveLefter.enabled = false;
			}

			bunnyHurtTime = Time.time;
			myAnim.SetBool ("bunnyHurt", true);
			myRigidbody.velocity = Vector2.zero;
			myRigidbody.AddForce (transform.up * bunnyJumpForce);
			myCollider.enabled = false;
			deathSfx.Play ();

		} else if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			jumpsCount = 2;
		}

	}
}
