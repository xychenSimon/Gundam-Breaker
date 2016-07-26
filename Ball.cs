using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Rigidbody2D rb;
	//public int numLives = 5;

	private Paddle paddle;	
	private Vector3 paddleToBallVector;
	public bool hasStarted = false;

	// Use this for initialization

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddleToBallVector + paddle.transform.position;

			if (Input.GetMouseButtonDown (0)) {
				print ("mouse clicked");
				hasStarted = true;
				rb.velocity = new Vector2 (4f, 10f);
			}
		} 
			
	}
		

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource audio = GetComponent<AudioSource> ();

		Vector2 tweak = new Vector2 (Random.Range (0f, 0.3f), Random.Range (0f, 0.3f)); 
		if (hasStarted) {
			audio.Play ();
			rb.velocity += tweak;
		}
	}

	/*bool OnTriggerEnter2D (Collider2D trigger) {
		numLives--;
		return true;
	}*/
}
