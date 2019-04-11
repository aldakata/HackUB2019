using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour, ObjectController {

	List<Action> actionq;
	
	public float speed = 1;
	private Direction movingDir;
	private Vector2Int destCell;
	bool ended;
	private Vector3 initialPos;

	float time;
	int index;
	
	
	// Use this for initialization
	void Start () {
		destCell = new Vector2Int (Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y));
		movingDir = Direction.NULL;
		time = 0;
		index = 0;
		ended = false;
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (ended) return;
		time += Time.deltaTime;
		ReadActionQueue ();
		if(movingDir != Direction.NULL){
			//Debug.Log ("moving");
			float x = transform.position.x;
			float y = transform.position.y;
			switch (movingDir) {

			case Direction.UP:

				y = y + speed * Time.deltaTime;
				Debug.LogFormat ("current pos: {0}, dest pos: {1}", y, destCell.y + 0.5f);
				if (y < destCell.y + 0.5f) transform.position = new Vector3 (x, y, 0.0f);
				else {
					transform.position = new Vector3(x, destCell.y + 0.5f, 0.0f);
					movingDir = Direction.NULL;
				}
				break;

			case Direction.DOWN:
				y = y - speed * Time.deltaTime;
				Debug.LogFormat ("current pos: {0}, dest pos: {1}", y, destCell.y + 0.5f);
				if (y > destCell.y + 0.5f) transform.position = new Vector3 (x, y, 0.0f);
				else {
					transform.position = new Vector3(x, destCell.y + 0.5f, 0.0f);
					movingDir = Direction.NULL;
				}
				break;

			case Direction.LEFT:
				x = x - speed * Time.deltaTime;
				if (x > destCell.x + 0.5f) transform.position = new Vector3 (x, y, 0.0f);
				else {
					transform.position = new Vector3(destCell.x + 0.5f, y, 0.0f);
					movingDir = Direction.NULL;
				}
				break;
				
				case Direction.RIGHT:
				x = x + speed * Time.deltaTime;
				if (x < destCell.x + 0.5f) transform.position = new Vector3 (x, y, 0.0f);
				else {
					transform.position = new Vector3(destCell.x + 0.5f, y, 0.0f);
					movingDir = Direction.NULL;
				}
				break;
			}
		}
	}
	
	public void SetActionList(List<Action> aq){
		actionq = aq;
	}
	
	private void ReadActionQueue(){
		Action a = actionq[index];
		if(time >= a.time){
			index++;
			switch(a.id){
				case 0:
				movingDir = Direction.UP;
				destCell.y++;
				break;
				
				case 1:
				movingDir = Direction.DOWN;
				destCell.y--;
				break;
				
				case 2:
				movingDir = Direction.LEFT;
				destCell.x--;
				break;
				
				case 3:
				movingDir = Direction.RIGHT;
				destCell.x++;
				break;
				
				case 4:
				//Interaction
				break;
				case 5:
				ended = true;
				gameObject.SetActive (false);
				break;
				
			}
		}
	}
	
	public void Reset(){
		gameObject.SetActive (true);
		transform.position = initialPos;
		destCell = new Vector2Int (Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y));
		movingDir = Direction.NULL;
		time = 0;
		index = 0;
		ended = false;
	}
}
