using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	int move;

	// Use this for initialization
	void Start () {
		move = 0; 
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("left")) move = -1;
		else if(Input.GetKey("right")) move = 1;
		else move = 0;
	}
	
	// FixedUpdate is called more often than Update and on a more consistent clock
	void FixedUpdate() {
		if(move == 1) {
			gameObject.transform.position += new Vector3(0.15f, 0, 0);
		}
		else if (move == -1) {
			gameObject.transform.position -= new Vector3(0.15f, 0, 0);
		}
		else return;
	}
}
