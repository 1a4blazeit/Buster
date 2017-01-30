using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
	
	GameObject player;

	// Use this for initialization
	void Start () {
		player = CreateObject("prefabs/PlayerModel");
		player.transform.position = new Vector3(4.5f, 2, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public GameObject CreateObject(string prefabName) {
		GameObject newObject = GameObject.Instantiate(Resources.Load(prefabName)) as GameObject;
		return newObject;
	}
}
