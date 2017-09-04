using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController1 : MonoBehaviour {

	public Sprite musicon;
	public Sprite musicoff;
	public Button music;
	public GameObject loadingscreen;
	public GameObject homescreen;
	public Slider slider;
	public Text linezen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void PlayPressed()
	{
		homescreen.SetActive (false);
		loadingscreen.SetActive (true);
		StartCoroutine (LoadAsynch ());
	}
	void QuitPressed()
	{
		Application.Quit ();
	}
	void MusicPressed()
	{
		if (this.GetComponent<AudioSource> ().isPlaying) 
		{
			this.GetComponent<AudioSource> ().Stop ();
			music.GetComponent<Image> ().sprite = musicoff;
		} 
		else
		{
			this.GetComponent<AudioSource> ().Play ();
			music.GetComponent<Image> ().sprite = musicon;
		}
	}
	IEnumerator LoadAsynch()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync ("Main");
		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			slider.value = progress;
			yield return null;
		}
	}

}
