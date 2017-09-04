using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	public GameObject gameoverscreen;

	private int score;
	public Text Score;
	private int bestscore;
	public Text gameoverscore;
	public Text HighScore;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 screenpos = Camera.main.WorldToViewportPoint (player.transform.position);
		if (screenpos.y < 0) 
		{
			Debug.Log ("Player Dead");

			CancelInvoke ("UpdateScore");
			gameoverscreen.SetActive (true);
			gameoverscore.text = "Your Score " + score.ToString();
			if (score > bestscore)
			{
				bestscore = score;
			}
			PlayerPrefs.SetInt ("High Score", bestscore);
			HighScore.text = "High Score " + bestscore.ToString ();
			Destroy (this.gameObject);

		}
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + (4.0f * Time.deltaTime), this.transform.position.z);
	}
}
