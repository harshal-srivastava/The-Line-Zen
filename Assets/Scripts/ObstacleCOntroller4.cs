using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCOntroller4 : MonoBehaviour {

	public GameObject trigger;
	public float speed = 2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (trigger.GetComponent<TriggerController1> ().ismoving == true) 
		{
			this.transform.position = new Vector3 (this.transform.position.x + (speed * Time.deltaTime), this.transform.position.y, this.transform.position.z);
		}
		
	}
}
