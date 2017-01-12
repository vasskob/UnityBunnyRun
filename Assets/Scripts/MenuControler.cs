using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControler : MonoBehaviour {

	public GameObject audioOffIcon;
	public GameObject audioOnIcon;
	public Text txtBestScore;

	// Use this for initialization
	void Start () {
		SoundState ();
		txtBestScore.text = (PlayerPrefs.GetFloat ("BestScore", 0).ToString("0.0"));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
		
	}
	public void StartGame(){
		//Application.loadedLevel ("GameScene");
		SceneManager.LoadScene ("Game");
	}

	public void ToggleSound(){
		if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
	
			PlayerPrefs.SetInt ("Muted", 1);
		} else {
			PlayerPrefs.SetInt ("Muted", 0);
		}
		SoundState ();
	}
	private void SoundState(){
		if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
			AudioListener.volume = 1;
			audioOnIcon.SetActive (true);
			audioOffIcon.SetActive (false);
		} else {
			AudioListener.volume = 0;
			audioOnIcon.SetActive (false);
			audioOffIcon.SetActive (true);

		}
	}

}
