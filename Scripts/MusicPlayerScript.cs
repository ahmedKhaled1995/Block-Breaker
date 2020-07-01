using UnityEngine;
using System.Collections;

public class MusicPlayerScript : MonoBehaviour {
	public static MusicPlayerScript MainMusic = null;
	public static bool IsMusicOn = false;

	void Awake(){
		//Debug.Log ("Music player awakes: " + GetInstanceID());
		if (MainMusic != null) {
			//Debug.Log ("Music player : " + GetInstanceID() + " has been destroyed.");
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		IsMusicOn = true;
		if (MainMusic == null) {
			MainMusic = this;
			gameObject.audio.Play();
			GameObject.DontDestroyOnLoad (gameObject);
		} 
		// gameObject is a pre-defined property
		// note that the game object is an instance of the game object the script is attaeched to
		// in this case it's the MusicPlayer game object
		/*
				public GameObject gameObject
				{
					get
					{
						return this.InternalGetGameObject ();
					}
				}
		 */
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Music player updates: " + GetInstanceID());
	}


}