using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController3 : MonoBehaviour {

	public float xspeed = 2.0f;
	public float yspeed = 2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponentInChildren<TriggerController1> ().ismoving == true)
		{
			Debug.Log ("working");
			this.transform.position = new Vector3 (this.transform.position.x + (xspeed * Time.deltaTime), this.transform.position.y + (yspeed * Time.deltaTime), this.transform.position.z);
		}
		
	}
}
