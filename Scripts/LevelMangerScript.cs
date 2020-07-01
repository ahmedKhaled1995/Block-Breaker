using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelMangerScript : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	void Update(){
		if(CanvasScript.IsGameStarted){
			Screen.showCursor = false;
		}
		if(CanvasScript.IsGamePaused){
			Screen.showCursor = true;
		}
	}

	public void LoadNextLevel(){
		int levelToLoad = Application.loadedLevel + 1;
		if (levelToLoad >= Application.levelCount){
			levelToLoad = 1;
		}
		BrickScript.numberOfBricksInGame = 0;
		CanvasScript.IsGamePaused = false;
		CanvasScript.IsGameStarted = false;
		Application.LoadLevel (levelToLoad);
	}


	public void QuitGame(){
		Application.Quit();
	}

	public void GoTo(string levelName){
		BrickScript.numberOfBricksInGame = 0;
		CanvasScript.IsGamePaused = false;
		CanvasScript.IsGameStarted = false;
		Application.LoadLevel (levelName);
	}

	public void PlayAgain(){
		Application.LoadLevel (EdgeColliderScript.CurrentLevel);
	}
	
}
