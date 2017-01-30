using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {
	
	//for the tile array, the square centered on (0.5, 0.5), is treated as (0, 0) to make conversion easy.
	GameObject[] tileArray;

	// Use this for initialization
	void Start () {
		tileArray = new GameObject[3];
		for (int i = 0; i < 3; i++) {
			tileArray[i] = GameObject.Find("MainModel").GetComponent<MainController>().CreateObject("prefabs/Tile");
			tileArray[i].transform.position = new Vector2(2, i);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
