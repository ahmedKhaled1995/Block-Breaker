using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private PaddleScriptAK paddle;
	private Vector3 ballPaddlePosDelta;
	private bool mouseClicked;
	private bool ballLunched;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<PaddleScriptAK>();
		//paddle = this.GetComponent<PaddleScriptAK>();    will not work because paddle is not a component of a ball
		ballPaddlePosDelta = this.transform.position - paddle.transform.position;
		this.transform.position = new Vector3 (paddle.transform.position.x, paddle.transform.position.y+ballPaddlePosDelta.y, paddle.transform.position.z);
		mouseClicked = false;
		ballLunched = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.rigidbody2D.velocity.y >= 15.5 || this.rigidbody2D.velocity.y >= 15.5){
			this.rigidbody2D.velocity = new Vector2 (12f, 12f);
		}
		if(!mouseClicked){
			this.transform.position = new Vector3 (paddle.transform.position.x, paddle.transform.position.y+ballPaddlePosDelta.y, paddle.transform.position.z);
		}
		if(Input.GetMouseButtonDown(0) && !CanvasScript.IsGamePaused){
			//Debug.Log ("Mouse clicked!");
			mouseClicked = true;
		}
		if(mouseClicked && !ballLunched && CanvasScript.IsGameStarted){
			this.rigidbody2D.velocity = new Vector2(2f, 10f);
			ballLunched = true;
			//Debug.Log ("ball lunched!");
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		if(MusicToggleScript.SoundEffects && mouseClicked && ballLunched){
			this.audio.Play ();
		}
		Vector2 tweak = new Vector2 (Random.Range(0.1f, 0.2f), Random.Range(0.1f, 0.2f));
		this.rigidbody2D.velocity += tweak;
	}
}
