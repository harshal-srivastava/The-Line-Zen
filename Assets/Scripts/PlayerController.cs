using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {

	private Vector3 lastpos;
	private Vector3 lastposscreentoworld;
	public GameObject gameoverscreen;

	private int score;
	public Text Score;
	private int bestscore;
	public Text gameoverscore;
	public Text HighScore;
	// Use this for initialization
	void Start () 
	{
		bestscore = PlayerPrefs.GetInt ("High Score", 0);
		gameoverscreen.SetActive (false);

		InvokeRepeating ("getpos", 0.001f, 0.1f);
		score = 0;
		InvokeRepeating ("UpdateScore", 0.001f, 1.0f);

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.up *  4.0f * Time.deltaTime);
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.GetTouch (0);



			if (touch.phase == TouchPhase.Moved)
			{ 
				Vector3 newpos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));
				float dist = newpos.x - lastposscreentoworld.x;

				if (newpos.x > lastposscreentoworld.x) 
				{
					this.transform.position = new Vector3 (this.transform.position.x + (10 * Time.deltaTime), this.transform.position.y, this.transform.position.z);
				}
				if (newpos.x < lastposscreentoworld.x) 
				{
					
					this.transform.position = new Vector3 (this.transform.position.x - (10 * Time.deltaTime), this.transform.position.y, this.transform.position.z);
				}
			}
			if (touch.phase == TouchPhase.Ended) 
			{
				lastpos = Input.GetTouch (0).position;
				lastposscreentoworld = Camera.main.ScreenToWorldPoint (lastpos);
			}
		}

		
	}
	void getpos()
	{
		
		lastpos = Input.GetTouch (0).position;
		lastposscreentoworld = Camera.main.ScreenToWorldPoint (lastpos);
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Obstacle") 
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
	}
	void UpdateScore()
	{
		score += 1;
		Score.text = "Score :" + score;
	}


}
