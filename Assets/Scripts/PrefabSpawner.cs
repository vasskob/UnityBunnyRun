using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour {
	private float nextSpawn = 0;
	public Transform prefabToSpawn;

	public AnimationCurve spawnCurve;
	public float curveLengthInSec=30f;
	private float startTime;
	private float jitter=0.6f;


	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			Instantiate (prefabToSpawn, transform.position, Quaternion.identity);
			//nextSpawn = Time.time + spawnRate + Random.Range (0, randomDellay);
			float curvePos=(Time.time - startTime)/curveLengthInSec;
			if (curvePos > 1f) {
				curvePos = 1f;
				startTime = Time.time;

			}
			nextSpawn = Time.time + spawnCurve.Evaluate (curvePos) + Random.Range(-jitter, jitter);
		}
	}
}
