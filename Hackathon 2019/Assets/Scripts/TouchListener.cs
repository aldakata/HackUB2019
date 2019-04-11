using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchListener : MonoBehaviour {

	PlayerController playerc;
	// Use this for initialization
	void Start () {
		playerc = Object.FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		playerc.DoAction (transform.name);
	}
}
