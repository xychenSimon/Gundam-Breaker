using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Number : MonoBehaviour {

	public Text number;
	private int num;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		num = LooseCollider.triggerCount;
		number.text = num.ToString();
	}
}
