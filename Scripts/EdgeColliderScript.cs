using UnityEngine;
using System.Collections;

public class EdgeColliderScript : MonoBehaviour {
	public static int CurrentLevel;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){

	}

	void OnTriggerEnter2D(Collider2D trigger){
		// write code here
		BrickScript.numberOfBricksInGame = 0;
		CanvasScript.IsGamePaused = false;
		CanvasScript.IsGameStarted = false;
		CurrentLevel = Application.loadedLevel;
		Application.LoadLevel (9);
		Screen.showCursor = true;
	}
}
