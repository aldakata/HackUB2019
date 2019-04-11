using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ObjectController{
	void Reset (); 
}

public class LevelController : MonoBehaviour {

	ObjectController [] objects;
	
	PlayerController player;
	List<ShadowController> shadows;
	public GameObject playerShadow;
	// Use this for initialization
	void Start () {
		player = Object.FindObjectOfType<PlayerController> ();
		GameObject[] o = GameObject.FindGameObjectsWithTag ("LevelObject");
		Debug.LogFormat ("Level objects size> {0}", o.Length);
		objects = new ObjectController [o.Length];
		for (int i = 0; i < o.Length; i++){
			objects [i] = o [i].GetComponent<ObjectController> ();
		}
		shadows = new List<ShadowController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void BanishPlayer(List<Action> actionq, Vector3 pos){
		player.Reset ();
		for (int i = 0; i < objects.Length; i++){
			objects [i].Reset ();
		}
		foreach(ShadowController shadow in shadows){
			shadow.Reset ();
		}
		if (actionq.Count > 0) {
			GameObject newShadow = Instantiate (playerShadow, pos, Quaternion.identity);
			newShadow.GetComponent<ShadowController> ().SetActionList (actionq);
			shadows.Add (newShadow.GetComponent<ShadowController> ());
		}
		Debug.Log ("Banish Player");
	}
	
	public void ResetLevel(){
		player.Reset ();
		for (int i = 0; i < objects.Length; i++){
			objects [i].Reset ();
		}
		
		foreach(ShadowController shadow in shadows){
			shadow.Reset ();
			shadow.gameObject.SetActive (false);
			//Destroy (shadow.gameObject);
		}
		shadows.Clear ();
		Debug.Log ("Reset Level");
	}
}
