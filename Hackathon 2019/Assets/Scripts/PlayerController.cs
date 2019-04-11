using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
	UP, DOWN, LEFT, RIGHT, NULL
}

public class PlayerController : MonoBehaviour {

	private Direction movingDir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void DoAction(InputAction ia){
		switch(ia){
		case InputAction.UP:
			break;
		case InputAction.DOWN:
			break;
		case InputAction.LEFT:
			break;
		case InputAction.RIGHT:
			break;
		case InputAction.A1:
			break;
		case InputAction.A2:
			break;
		
		}
	}
}
