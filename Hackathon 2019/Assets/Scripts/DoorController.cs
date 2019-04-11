using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public Sprite openedDoor;
	public Sprite closedDoor;
	public bool isOpen = false;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = openedDoor; //Change sprite to open door
	}

	// Update is called once per frame
	void Update () {

		if (isOpen) {

			this.gameObject.GetComponent<SpriteRenderer>().sprite = openedDoor; //Change sprite to open door
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			

		} else {
		
			this.gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor; //Change sprite to closed door
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		}

	}
	
	public void setDoorState(bool state){ //Set isOpen to desired state
		isOpen = state;
	}
}
