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
			this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true; //Change collider to trigger

		} else {
		
			this.gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor; //Change sprite to closed door
			this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false; //Set collider to normal
		}

	}
	
	public void setDoorState(bool state){ //Set isOpen to desired state
		isOpen = state;
	}
}
