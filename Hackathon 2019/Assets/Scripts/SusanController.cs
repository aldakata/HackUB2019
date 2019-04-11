using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusanController : MonoBehaviour {

	Animator anim;
	private float currentTime = 0;
	private float step = 0.1f;
	private GameObject btnA1;
	private GameObject btnR;
	private GameObject btnUp;
	private GameObject btnLeft;
	private GameObject btnRight;
	private GameObject btnDown;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		btnA1 = GameObject.Find ("A1");
		btnR = GameObject.Find ("R");
		btnUp = = GameObject.Find ("UP");
		btnDown = GameObject.Find ("DOWN");
		btnLeft = GameObject.Find ("LEFT");
		btnRight = GameObject.Find ("RIGHT");
		btnA1.SetActive (false);
		btnR.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log ("Test");
		anim.SetBool ("End", true);
		StartCoroutine (EndRoutine ());
	}

	IEnumerator EndRoutine(){
	
		while (currentTime < 1.8) {
			yield return new WaitForSeconds (step);
			currentTime += step;

		}
		Debug.Log ("Finish");
		this.transform.position = new Vector3(0, 100, 0);
		btnUp.SetActive (false);
		btnDown.SetActive (false);
		btnLeft.SetActive (false);
		btnRight.SetActive (false);
		btnA1.SetActive (true);
	}
}
