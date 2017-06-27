using UnityEngine;
using System.Collections;

public class SplashScreenController : MonoBehaviour {

	public AudioClip introMusic;

	void Start () {
		AudioSource.PlayClipAtPoint(introMusic, transform.position);
		Invoke("LoadStartScreen", 5);
	}
	
	void LoadStartScreen()
	{
		GameObject.FindObjectOfType<LevelManager>().LoadNextLevel();
	}
}
