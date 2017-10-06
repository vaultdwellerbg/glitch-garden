using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelProgress : MonoBehaviour {

	[Tooltip("Level runtime in seconds")]
	public float levelRuntime = 120;	
	
	private float timeSinceStart = 0f;	
	private Slider levelProgressSlider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private bool levelCompleted = false;
	
	void Start()
	{
		levelProgressSlider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void Update () 
	{
		if (levelCompleted) return;
	
		timeSinceStart += Time.deltaTime;
		levelProgressSlider.value = timeSinceStart / levelRuntime;
		if (timeSinceStart > levelRuntime) 
		{
			EndLevel();
		}
	}

	void EndLevel ()
	{
		levelCompleted = true;
		GameObject.FindObjectOfType<MessagesController>().ShowLevelComplete();
		audioSource.Play();
		GameProgress.SetLevel(Application.loadedLevel);	
		Invoke("LoadNextLevel", audioSource.clip.length);
	}
	
	private void LoadNextLevel()
	{
		levelManager.LoadNextLevel();
	}
	
	public bool IsLevelCompleted()
	{
		return levelCompleted;
	}
	
	public float GetRemainingTime()
	{
		return levelRuntime - timeSinceStart;
	}
}
