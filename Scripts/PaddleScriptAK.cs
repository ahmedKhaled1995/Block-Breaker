using UnityEngine;
using System.Collections;

public class PaddleScriptAK : MonoBehaviour {
	public bool autoPlay;
	// Use this for initialization
	void Start () {
			float relativeXPosition = (Input.mousePosition.x / Screen.width) * 16;
			float min = 0.5f;
			float max = 15.5f;
			relativeXPosition = Mathf.Clamp(relativeXPosition, min, max);
			Vector3 movingPosition = new Vector3 (relativeXPosition, this.transform.position.y, 0.0f);
			this.transform.position = movingPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(!CanvasScript.IsGamePaused){
			if (!autoPlay) {
				UserControls ();
			} else {
				AutoPlay();
			}
		}
	}

	void UserControls(){
		// scale = background image width / pixels per unit of the background image
		// relativeXPosition = (Input.mousePosition.x / Screen.width) * scale;
		float relativeXPosition = (Input.mousePosition.x / Screen.width) * 16;
		float min = 1.2f;
		float max = 14.8f;
		relativeXPosition = Mathf.Clamp(relativeXPosition, min, max);
		Vector3 movingPosition = new Vector3 (relativeXPosition, this.transform.position.y, 0.0f);
		this.transform.position = movingPosition;
	}

	void AutoPlay(){
		BallScript ball = GameObject.FindObjectOfType<BallScript>();
		Vector3 movingPosition = new Vector3 (ball.transform.position.x , this.transform.position.y, 0.0f);
		this.transform.position = movingPosition;
	}
}
