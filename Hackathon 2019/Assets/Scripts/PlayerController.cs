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

	Animator anim;
	public float speed = 1;
	private Direction movingDir;
	private Vector2Int destCell;
	public GameObject wallTiles;
	private WallTilesController wc;
	LevelController lvlC;
	SpriteRenderer sr;
	int lookDir;

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
		lvlC = Object.FindObjectOfType<LevelController> ();
		anim = GetComponent<Animator> ();
		anim.SetBool ("Moving", false);
		sr = GetComponent<SpriteRenderer> ();
		lookDir = 0;
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
				//Debug.LogFormat ("current pos: {0}, dest pos: {1}", y, destCell.y + 0.5f);
				if (y < destCell.y + 0.5f) transform.position = new Vector3 (x, y, 0.0f);
				else {
					transform.position = new Vector3(x, destCell.y + 0.5f, 0.0f);
					StopMovement ();
				}
				break;

			case Direction.DOWN:
				y = y - speed * Time.deltaTime;
				//Debug.LogFormat ("current pos: {0}, dest pos: {1}", y, destCell.y + 0.5f);
				if (y > destCell.y + 0.5f) transform.position = new Vector3 (x, y, 0.0f);
				else {
					transform.position = new Vector3(x, destCell.y + 0.5f, 0.0f);
					StopMovement ();
				}
				break;

			case Direction.LEFT:
				x = x - speed * Time.deltaTime;
				if (x > destCell.x + 0.5f) transform.position = new Vector3 (x, y, 0.0f);
				else {
					transform.position = new Vector3(destCell.x + 0.5f, y, 0.0f);
					StopMovement ();
				}
				break;
				
				case Direction.RIGHT:
				x = x + speed * Time.deltaTime;
				if (x < destCell.x + 0.5f) transform.position = new Vector3 (x, y, 0.0f);
				else {
					transform.position = new Vector3(destCell.x + 0.5f, y, 0.0f);
					StopMovement ();
				}
				break;
			}
		}else{
			Collider2D c = Physics2D.OverlapPoint (new Vector2 (transform.position.x, transform.position.y));
			if (c != null && c.name == "Door") lvlC.ResetLevel ();
		}
	}
	
	void StopMovement(){
		movingDir = Direction.NULL;
		anim.SetBool ("Moving", false);
		Debug.Log ("Stop Movement");
	}
	
	public void DoAction(string ia){
		Debug.LogFormat ("Player action: {0}", ia);
		switch(ia){
		case "UP":
		if(movingDir == Direction.NULL && !wc.IsCellSolid(destCell.x, destCell.y+1)){
			movingDir = Direction.UP;
			destCell.y++;
			actionq.Add (new Action (0, time));
			anim.SetBool ("Moving", true);
			Debug.Log ("Start Movement");
		}
		break;
		case "DOWN":
		if(movingDir == Direction.NULL && !wc.IsCellSolid(destCell.x, destCell.y-1)){
			movingDir = Direction.DOWN;
			destCell.y--;
			actionq.Add (new Action (1, time));
			anim.SetBool ("Moving", true);
			Debug.Log ("Start Movement");
		}
		break;
		case "LEFT":
		if(movingDir == Direction.NULL && !wc.IsCellSolid(destCell.x-1, destCell.y)){
			movingDir = Direction.LEFT;
			destCell.x--;
			actionq.Add (new Action (2, time));
			anim.SetBool ("Moving", true);
			Debug.Log ("Start Movement");
			if(lookDir == 0){
					lookDir = 1;
					sr.flipX = true;
			}
			
		}
		break;
		case "RIGHT":
		if(movingDir == Direction.NULL && !wc.IsCellSolid(destCell.x+1, destCell.y)){
			movingDir = Direction.RIGHT;
			destCell.x++;
			actionq.Add (new Action (3, time));
			anim.SetBool ("Moving", true);
			Debug.Log ("Start Movement");
			if(lookDir == 1){
					lookDir = 0;
					sr.flipX = false;
			}
		}
		break;
		case "A1":
			actionq.Add (new Action (4, time));
			lvlC.BanishPlayer (actionq, initialPos);
			break;
		case "R":
			lvlC.ResetLevel ();
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
