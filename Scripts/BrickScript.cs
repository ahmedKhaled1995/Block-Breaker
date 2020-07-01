using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {
	public AudioClip crack;
	private int maxHits;
	private int numOfHits;
	public Sprite[] sprites;
	public static int numberOfBricksInGame = 0;
	private bool isBreakable;
	public GameObject smokeParticles;   // prefab

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag.Equals ("Breakable"));
		this.numOfHits = 0;
		this.maxHits = this.sprites.Length + 1;
		if(isBreakable){
			numberOfBricksInGame++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(MusicToggleScript.SoundEffects && this.tag == "Breakable"){
			AudioSource.PlayClipAtPoint (crack, this.transform.position, 0.5f);
		}
		if(isBreakable){
			HandleBreak();
		}
		if(numberOfBricksInGame <= 0){
			LevelMangerScript script = GameObject.FindObjectOfType<LevelMangerScript>();
			script.LoadNextLevel();
		}
	}

	void HandleBreak(){
		numOfHits++;
		if(numOfHits >= maxHits){
			numberOfBricksInGame--;
			GameObject smokeCopy = (GameObject)Instantiate(smokeParticles, this.transform.position,  Quaternion.identity);
			smokeCopy.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
			smokeCopy.particleSystem.particleSystem.Play();
			float totalDuration = smokeCopy.particleSystem.duration + smokeCopy.particleSystem.startLifetime;   // 2 = 1 + 1     in this game
			Destroy(smokeCopy, totalDuration);
			Destroy(gameObject);
		}else if(this.sprites[numOfHits-1]){
			this.GetComponent<SpriteRenderer>().sprite = this.sprites[numOfHits-1];
		}
	}


}
