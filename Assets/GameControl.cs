using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public GameObject prefab1;
	public GameObject prefab2;
	List<GameObject> prefabs;
	public GameObject[] arrayofprefabs;
	public GameObject gameoverscreen;
	public GameObject homeloadingscreen;
	public GameObject retryloadingscreen;
	public Slider homselider;
	public Slider retryslider;



	// Use this for initialization
	void Start () {
		homeloadingscreen.SetActive (false);
		retryloadingscreen.SetActive (false);
		prefabs = new List<GameObject>();
		prefabs.Add (prefab1);
		prefabs.Add (prefab2);
		InvokeRepeating ("SpawnNewPrefab", 0.001f, 6.0f);


	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	public void SpawnNewPrefab()
	{
		
		int randomnumber = Random.Range (0, arrayofprefabs.Length);
		GameObject item = arrayofprefabs [randomnumber] as GameObject;
		GameObject lastprefab = prefabs [prefabs.Count - 1] as GameObject;
		float itemheight = lastprefab.GetComponent<BoxCollider2D> ().bounds.size.y;
		GameObject newprefab = Instantiate (item, new Vector3(0.5342f, lastprefab.transform.position.y, 0.0f), lastprefab.transform.rotation);
		newprefab.transform.position = new Vector3 (newprefab.transform.position.x, newprefab.transform.position.y + itemheight, newprefab.transform.position.z);
		prefabs.Add (newprefab);
	}
	void RetryPressed()
	{
		Debug.Log ("retry pressed");
		gameoverscreen.SetActive (false);
		retryloadingscreen.SetActive (true);
		StartCoroutine (LoadAsynchRetry ());
	}
	void HomePressed()
	{
		gameoverscreen.SetActive (false);
		homeloadingscreen.SetActive (true);
		StartCoroutine (LoadAsynchHome ());
	}
	void QuitPressed()
	{
		Application.Quit ();
	}
	IEnumerator LoadAsynchRetry()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync ("Main");
		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			retryslider.value = progress;
			yield return null;
		}
	}
	IEnumerator LoadAsynchHome()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync ("Menu");
		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			homselider.value = progress;
			yield return null;
		}
	}
}
