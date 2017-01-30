using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	int move;
	static float gravity = 9.81f;
	float left, right, up, down; //bounding box edge positions

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
		left = transform.position.x + 0.5f;
		right = transform.position.x - 0.5f;
		up = transform.position.y + 1.0f;
		down = transform.position.y - 1.0f;
		
		if(move == 1) {
			gameObject.transform.position += new Vector3(0.15f, 0, 0);
		}
		else if (move == -1) {
			gameObject.transform.position -= new Vector3(0.15f, 0, 0);
		}
		else return;
	}
}
