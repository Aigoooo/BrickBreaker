using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


	private int timesHit;
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private LevelManager levelmanager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		levelmanager = Object.FindObjectOfType<LevelManager> ();
		timesHit = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D (Collision2D Coliision) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.5f);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits (){
		timesHit++;
		int maxHit = hitSprites.Length + 1;
		if (timesHit >= maxHit) {
			breakableCount--;
			Debug.Log(breakableCount);
			levelmanager.BricksDestroyed();
			PuffSmoke();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void PuffSmoke() {
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
		Destroy (gameObject);
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError("Sprite is missing");
		}
	}
	void SimulateWin() {
		levelmanager.LoadNextLevel ();
	}
}
