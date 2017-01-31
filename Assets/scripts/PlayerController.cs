using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	int move;
	static float gravity = -9.81f;
	static float speed = 0.15f; //horizontal movement per fixedUpdate tick
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
		//find the edges of the bounding box post movement
		left = transform.position.x - 0.49f - speed;
		right = transform.position.x + 0.49f + speed;
		up = transform.position.y + 0.99f;
		down = transform.position.y - 1.0f;
		int maxHori = Mathf.FloorToInt(right); //these are the coordinates of the squares (in array) that the box intersects)
		int minHori = Mathf.FloorToInt(left);
		int maxVerti = Mathf.FloorToInt(up);
		int minVerti = Mathf.FloorToInt(down);
		int rowsIntersected = maxVerti - minVerti + 1;
		int colsIntersected = maxHori - minHori + 1;
		GameObject[,] tileMap = GameObject.Find("EnvironmentModel").GetComponent<EnvironmentController>().tileArray;
		bool unobstructed = true;
		
		
		if(move == 1) {
			float maxMove = speed;
			
			for(int i = 0; i < rowsIntersected; i++) {
				if(tileMap[minVerti + i, maxHori].tag == "Obstacle") {
					unobstructed = false;
					maxMove = Mathf.Min(maxMove, (tileMap[minVerti + i, maxHori].transform.position.x - 0.49f) - (transform.position.x + 0.49f));
				}
			}
			if(unobstructed) transform.position += new Vector3(speed, 0, 0);
			else transform.position += new Vector3(maxMove, 0, 0);
				
			
		}
		else if (move == -1) {
			float maxMove = -speed;
			
			for(int i = 0; i < rowsIntersected; i++) {
				if(tileMap[minVerti + i, minHori].tag == "Obstacle") {
					unobstructed = false;
					maxMove = Mathf.Max(maxMove, (tileMap[minVerti + i, minHori].transform.position.x + 0.49f) - (transform.position.x - 0.49f));
				}
			}
			if(unobstructed) transform.position += new Vector3(-speed, 0, 0);
			else transform.position += new Vector3(maxMove, 0, 0);
		}
		else return;
	}
}
