using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {

	private LevelManagement levelManager;
	private Ball ball;

	public static int triggerCount = 10;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManagement> ();
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	void OnTriggerEnter2D (Collider2D trigger) {
		print ("Trigger");	
		triggerCount--;
		print (triggerCount);
		if (triggerCount <= 0) {
			triggerCount = 10;
			levelManager.LoadLevel ("Lose");

		} else {
			isTrigger ();
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");
	}

	private bool isTrigger() {
		ball.hasStarted = false;
		return true;
	}
}
