using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyControler : MonoBehaviour {
	private Rigidbody2D myRigidbody;
	private Animator myAnim;
	public float bunnyJumpForce=500f;
	public float bunnyTorque=10f;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Jump")) {
			myRigidbody.AddForce (transform.up * bunnyJumpForce);
			// myRigidbody.AddForceAtPosition (transform.);
		}
	//	myAnim.SetFloat ("wVelocity", Mathf.Abs(myRigidbody.velocity.y));
		myAnim.SetFloat ("wVelocity", myRigidbody.velocity.y);

	}
	void OnCollisionEnter2D (Collision2D collision){
		if (collision.collider.gameObject.layer==LayerMask.NameToLayer("Enemy")){

		//	Application.LoadLevel (Application.loadedLevel);
			SceneManager.LoadScene ("maneScene");		
		}

	}
}
