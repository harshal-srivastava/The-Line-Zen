using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController1 : MonoBehaviour {

	public bool ismoving = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log ("Player enter");
			ismoving = true;
		}
	}
}
