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
		return t != null;
	}
}
