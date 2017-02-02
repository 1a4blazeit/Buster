using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {
	
	//for the tile array, the square centered on (0.5, 0.5), is treated as (0, 0) to make conversion easy.
	public GameObject[,] tileArray;

	// Use this for initialization
	void Start () {
		
		int arrayRows = 10;
		int arrayCols = 13;
		tileArray = new GameObject[arrayRows,arrayCols]; //[X,Y] is X rows and Y columns
		
		for(int i = 0; i < arrayRows;  i++) {
			for(int j = 0; j < arrayCols; j++) {
				if(j == 0 || j == arrayCols - 1 || i == 0 || i == arrayRows - 1){
					tileArray[i, j] = GameObject.Find("MainModel").GetComponent<MainController>().CreateObject("prefabs/Tile");
					tileArray[i, j].transform.position = new Vector3((0.5f + j), (0.5f + i), 0);
				}
				else {
					tileArray[i, j] = GameObject.Find("MainModel").GetComponent<MainController>().CreateObject("prefabs/UndergroundTile");
					tileArray[i, j].transform.position = new Vector3((0.5f + j), (0.5f + i), 0);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
