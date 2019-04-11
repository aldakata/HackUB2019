using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//sets isPressed to true when pressed
	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log ("Next Level");
		//SceneManager.LoadScene("name")
	}
}
