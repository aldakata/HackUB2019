using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, ObjectController{ 

	public Sprite openedDoor;
	public Sprite closedDoor;
	public bool isOpen = false;
	public bool state;

	// Use this for initialization
	void Start () {
		state = isOpen;
		if (state) {

			this.gameObject.GetComponent<SpriteRenderer>().sprite = openedDoor; //Change sprite to open door
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			

		} else {
		
			this.gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor; //Change sprite to closed door
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {
	}
	
	
	public void SwitchState(bool state){
		this.state = state;
		if (state) {

			this.gameObject.GetComponent<SpriteRenderer>().sprite = openedDoor; //Change sprite to open door
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			

		} else {
		
			this.gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor; //Change sprite to closed door
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		}
	}
	
	public void Reset(){
		Debug.Log ("door reset");
		state = isOpen;
		if (state) {

			this.gameObject.GetComponent<SpriteRenderer>().sprite = openedDoor; //Change sprite to open door
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			

		} else {
		
			this.gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor; //Change sprite to closed door
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		}
	}
}
