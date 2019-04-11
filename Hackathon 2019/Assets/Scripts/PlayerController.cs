using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
	UP, DOWN, LEFT, RIGHT, NULL
}

public class Action{
	public int id;
	public float time;
	
	public Action(int id, float time){
		this.id = id;
		this.time = time;
	}
	
}

public class PlayerController : MonoBehaviour, ObjectController {

	public float speed = 1;
	private Direction movingDir;
	private Vector2Int destCell;
	public GameObject wallTiles;
	private WallTilesController wc;
	LevelController lvlC;

	private Vector3 initialPos;

	private List<Action> actionq;
	float time;
	
	private GameObject interactableObject;
	// Use this for initialization
	void Start () {
		destCell = new Vector2Int (Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y));
		movingDir = Direction.NULL;
		wc = wallTiles.GetComponent<WallTilesController> ();
		actionq = new List<Action> ();
		time = 0;
		initialPos = transform.position;
		lvlC = GetComponent<LevelController> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime; 
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
	
	public void DoAction(string ia){
		Debug.LogFormat ("Player action: {0}", ia);
		switch(ia){
		case "UP":
		if(movingDir == Direction.NULL && !wc.IsCellSolid(destCell.x, destCell.y+1)){
			movingDir = Direction.UP;
			destCell.y++;
			actionq.Add (new Action (0, time));
		}
		break;
		case "DOWN":
		if(movingDir == Direction.NULL && !wc.IsCellSolid(destCell.x, destCell.y-1)){
			movingDir = Direction.DOWN;
			destCell.y--;
			actionq.Add (new Action (1, time));
		}
		break;
		case "LEFT":
		if(movingDir == Direction.NULL && !wc.IsCellSolid(destCell.x-1, destCell.y)){
			movingDir = Direction.LEFT;
			destCell.x--;
			actionq.Add (new Action (2, time));
		}
		break;
		case "RIGHT":
		if(movingDir == Direction.NULL && !wc.IsCellSolid(destCell.x+1, destCell.y)){
			movingDir = Direction.RIGHT;
			destCell.x++;
			actionq.Add (new Action (3, time));
		}
		break;
		case "A1":
			//interactableObject.GetComponent<Interactable> ().Interaction ();
			actionq.Add (new Action (4, time));
			break;
		case "A2":
			actionq.Add (new Action (5, time));
			lvlC.BanishPlayer (actionq, initialPos);
			break;
		}
	}
	
	public void Reset(){
		transform.position = initialPos;
		movingDir = Direction.NULL;
		destCell = new Vector2Int (Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y));
		time = 0;
		actionq = new List<Action> ();
	}
}
