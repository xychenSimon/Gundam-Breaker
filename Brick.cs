using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	//private GameObject smokePuff;
	private LevelManagement levelManager;
	private int timesHit;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "breakable");
		if (isBreakable) {
			breakableCount++;
			print (breakableCount);
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManagement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		//SimulateWin ();
		if (timesHit >= maxHits) {
			breakableCount--;
			print (breakableCount); 
			levelManager.BrickDestroyed();
			GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
	}
	//TODO remove this function after the actual win function is done

	void SimulateWin() {
		levelManager.LoadNextLevel ();
	}
}
