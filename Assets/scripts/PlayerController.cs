using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	int move; //-1 is moving left, 0 is no horizontal movement, 1 is moving right
	int jump; //1+ queues up a jump, 0 is midair, -1 is grounded
	static float gravity = -9.81f;
	static float speed = 0.15f;
	float horizSpeed; //horizontal movement per fixedUpdate tick
	float vertiSpeed; //vertical speed per fixedUpdate tick
	float left, right, up, down; //bounding box edge coordinate intersecctions

	// Use this for initialization
	void Start () {
		move = 0; 
		jump = -1;
		horizSpeed = 0;
		vertiSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("left")) move = -1;
		else if(Input.GetKey("right")) move = 1;
		else move = 0;
		
		if(Input.GetKey("up")) jump = 1;
		else if(Input.GetKey("down")) jump = -1;
		else jump = 0;
	}
	
	// FixedUpdate is called more often than Update and on a more consistent clock
	void FixedUpdate() {
		//find the edges of the bounding box post movement. by making them slightly smaller than unit it lets them sneak through gaps without affecting size in a meaningful way
		if(move == 1) horizSpeed = speed;
		else if(move == -1) horizSpeed = -speed;
		else horizSpeed = 0f;
		
		if(jump == 1) vertiSpeed = speed;
		else if(jump == -1) vertiSpeed = -speed;
		else vertiSpeed = 0f;
		
		
		//define the hitboxes
		left = transform.position.x - 0.45f;
		right = transform.position.x + 0.45f;
		up = transform.position.y + 0.95f;
		down = transform.position.y - 1.0f;
		
		//find the array rows that correspond to hitbox edges
		int maxHori = Mathf.FloorToInt(right);
		int minHori = Mathf.FloorToInt(left);
		int maxVerti = Mathf.FloorToInt(up);
		int minVerti = Mathf.FloorToInt(down);
		
		//figure out how many rows/cols will have to be iterated through in future checks
		int rowsIntersected = maxVerti - minVerti + 1;
		int colsIntersected = maxHori - minHori + 1;
		
		GameObject[,] tileMap = GameObject.Find("EnvironmentModel").GetComponent<EnvironmentController>().tileArray;

		
		//first check that the moved-towards edge isn't inside an obstacle
		//if it is, cannot move further in that direction
		//if it isn't, move up until in contact or the move speed
		float maxMove = horizSpeed;
		if(move == 1) {
			for(int i = 0; i < rowsIntersected; i++) {
				if(tileMap[minVerti + i, maxHori].tag == "Obstacle") {
					maxMove = 0;
				}
				else if(tileMap[minVerti + i, maxHori + 1].tag == "Obstacle") {
					maxMove = Mathf.Min(maxMove, (tileMap[minVerti + i, maxHori + 1].transform.position.x - 0.5f) - (transform.position.x + 0.5f));
				}
			}
			transform.position += new Vector3(maxMove, 0, 0);	
		}
		else if (move == -1) {
			for(int i = 0; i < rowsIntersected; i++) {
				if(tileMap[minVerti + i, minHori].tag == "Obstacle") { //
					maxMove = 0;
				}
				else if(tileMap[minVerti + i, minHori - 1].tag == "Obstacle") {
					maxMove = Mathf.Max(maxMove, (tileMap[minVerti + i, minHori - 1].transform.position.x + 0.5f) - (transform.position.x - 0.5f));
				}
			}
			transform.position += new Vector3(maxMove, 0, 0);
		}
		
		//check grounded/jump status, and if appropriate, set new vertiSpeed
		
		maxMove = vertiSpeed;
		if(jump == 1) {
			for(int i = 0; i < colsIntersected; i++) {
				if(tileMap[maxVerti, minHori + i].tag == "Obstacle") {
					maxMove = 0;
				}
				else if(tileMap[maxVerti + 1, minHori + i].tag == "Obstacle") {
					maxMove = Mathf.Min(maxMove, (tileMap[maxVerti + 1, minHori + i].transform.position.y - 0.5f) - (transform.position.y + 1.0f));
				}
			}
			transform.position += new Vector3(0, maxMove, 0);
		}
		else if (jump == -1) {
			for(int i = 0; i < colsIntersected; i++) {
				if(tileMap[minVerti, minHori + i].tag == "Obstacle") {
					maxMove = 0;
				}
				else if(tileMap[minVerti - 1, minHori + i].tag == "Obstacle") {
					maxMove = Mathf.Max(maxMove, (tileMap[minVerti - 1, minHori + i].transform.position.y + 0.5f) - (transform.position.y - 1.0f));
				}
			}
			transform.position += new Vector3(0, maxMove, 0);
		}
	}
}
