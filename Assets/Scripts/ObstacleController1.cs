using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController1 : MonoBehaviour {


	public float movingspeed = 2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.GetComponentInChildren<TriggerController1> ().ismoving == true)
		{
			Debug.Log ("working");
			this.transform.position = new Vector3 (this.transform.position.x + (movingspeed * Time.deltaTime), this.transform.position.y, this.transform.position.z);
		}
	}
}
