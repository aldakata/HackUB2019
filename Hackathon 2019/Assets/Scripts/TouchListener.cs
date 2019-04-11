using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchListener : MonoBehaviour {

	PlayerController playerc;
	// Use this for initialization
	bool active;
	void Start () {
		playerc = Object.FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(active){
			playerc.DoAction (transform.name);
		}
	}
	
	void OnMouseUp(){
		active = false;
	}
	void OnMouseDown(){
		active = true;
	}
}
