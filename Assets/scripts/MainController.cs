using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public GameObject CreateObject(string prefabName) {
		GameObject newObject = GameObject.Instantiate(Resources.Load(prefabName)) as GameObject;
		return newObject;
	}
}
