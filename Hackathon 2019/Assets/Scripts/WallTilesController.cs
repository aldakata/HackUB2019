using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallTilesController : MonoBehaviour {

	private Tilemap walls;
	// Use this for initialization
	void Start () {
		walls = GetComponent<Tilemap> ();
	}
	
	
	public bool IsCellSolid(int x, int y){
		Tile t = (Tile)walls.GetTile (new Vector3Int (x, y, 0));
		Collider2D c = Physics2D.OverlapPoint (new Vector2 (x + 0.5f, y + 0.5f));
		
		if(c != null){
			Debug.LogFormat ("collider {0}", c.gameObject.name);
		}
		bool doorCollision = (c != null && c.gameObject.name == "Door");
		return t != null || doorCollision;
	}
}
