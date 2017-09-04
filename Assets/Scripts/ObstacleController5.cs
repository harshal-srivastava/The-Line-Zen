using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController5 : MonoBehaviour {

	public GameObject trigger;
	public float rotation = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (trigger.GetComponent<TriggerController1> ().ismoving == true)
		{
			this.transform.Rotate (0, 0, rotation * Time.deltaTime);
		}
	}
}
