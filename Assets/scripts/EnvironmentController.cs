using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {
	
	//for the tile array, the square centered on (0.5, 0.5), is treated as (0, 0) to make conversion easy.

	// Use this for initialization
	void Start () {
		GameObject tile = GameObject.Find("MainModel").GetComponent<MainController>().CreateObject("prefabs/Tile");
		tile.transform.position = new Vector2(3, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
