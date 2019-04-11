using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public Sprite pressedPlate;
	public Sprite normalPlate;
	public GameObject[] door;
	private DoorController[] dController;
	public int isPressed = 0;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = normalPlate;
		dController = new DoorController [door.Length];
		for (int i = 0; i < door.Length; i++){
			dController[i] = door[i].GetComponent<DoorController> ();
		}
		
	}

	//sets isPressed to true when pressed
	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log ("Test");
		gameObject.GetComponent<SpriteRenderer> ().sprite = pressedPlate;
		isPressed++;
		foreach(DoorController dc in dController)dc.SwitchState ();
	}

	void OnTriggerExit2D(Collider2D col){
		isPressed--;
		if (isPressed <= 0) {
		
			gameObject.GetComponent<SpriteRenderer> ().sprite = normalPlate;
			foreach(DoorController dc in dController)dc.SwitchState ();
		}
	}
}
