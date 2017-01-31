using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	int move;
	static float gravity = 9.81f;
	float left, right, up, down; //bounding box edge coordinate intersecctions

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
		left = transform.position.x - 0.5f;
		right = transform.position.x + 0.5f;
		up = transform.position.y + 1.0f;
		down = transform.position.y - 1.0f;
		int maxHori = Mathf.FloorToInt(right); //these are the coordinates of the squares (in array) that the box intersects)
		int minHori = Mathf.FloorToInt(left);
		int maxVerti = Mathf.FloorToInt(up);
		int minVerti = Mathf.FloorToInt(down);
		
		
		if(move == 1) {
			if(GameObject.Find("EnvironmentModel").GetComponent<EnvironmentController>().tileArray[maxVerti, maxHori].tag != "Obstacle")
				gameObject.transform.position += new Vector3(0.15f, 0, 0);
		}
		else if (move == -1) {
			if(GameObject.Find("EnvironmentModel").GetComponent<EnvironmentController>().tileArray[maxVerti, minHori].tag != "Obstacle")
				gameObject.transform.position -= new Vector3(0.15f, 0, 0);
		}
		else return;
	}
}
