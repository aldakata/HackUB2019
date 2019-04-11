using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public Sprite pressedPlate;
	public Sprite normalPlate;
	public GameObject door;
	private DoorController dController;
	public int isPressed = 0;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = normalPlate;
		dController = door.GetComponent<DoorController> ();
	}

	//sets isPressed to true when pressed
	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log ("Test");
		gameObject.GetComponent<SpriteRenderer> ().sprite = pressedPlate;
		isPressed++;
		dController.setDoorState (true);
	}

	void OnTriggerExit2D(Collider2D col){
		isPressed--;
		if (isPressed <= 0) {
		
			gameObject.GetComponent<SpriteRenderer> ().sprite = normalPlate;
			dController.setDoorState (false);
		}
	}
}
