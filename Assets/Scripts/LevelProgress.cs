using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelProgress : MonoBehaviour {

	[Tooltip("Level runtime in seconds")]
	private float levelRuntime = 120;
	
	private Slider levelProgressSlider;
	private GameObject levelCompletedDisplay;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private bool levelCompleted = false;
	
	void Start()
	{
		levelProgressSlider = GetComponent<Slider>();
		levelCompletedDisplay = GameObject.Find("LevelCompleted");
		levelCompletedDisplay.SetActive(false);
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void Update () 
	{
		if (levelCompleted) return;
	
		levelProgressSlider.value = Time.realtimeSinceStartup / levelRuntime;
		if (Time.realtimeSinceStartup > levelRuntime) 
		{
			EndLevel();
		}
	}

	void EndLevel ()
	{
		levelCompleted = true;
		levelCompletedDisplay.SetActive(true);
		audioSource.Play();
		Invoke ("LoadNextLevel", audioSource.clip.length);
	}
	
	private void LoadNextLevel()
	{
		levelManager.LoadNextLevel();
	}
	
	public bool IsLevelCompleted()
	{
		return levelCompleted;
	}
}
