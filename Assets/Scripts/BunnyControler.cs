using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyControler : MonoBehaviour {
	private Rigidbody2D myRigidbody;
	private Animator myAnim;
	public float bunnyJumpForce=500f;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Jump")) {
			myRigidbody.AddForce (transform.up * bunnyJumpForce);
		}
	//	myAnim.SetFloat ("wVelocity", Mathf.Abs(myRigidbody.velocity.y));
		myAnim.SetFloat ("wVelocity", myRigidbody.velocity.y);

	}
}
