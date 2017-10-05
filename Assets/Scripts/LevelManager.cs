using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) 
	{
		Application.LoadLevel(name);
	}
	
	public void LoadLevel(int index)
	{
		Application.LoadLevel(index);
	}
	
	public void LoadUnlockedLevel()
	{
		int unlockedLevel = PlayerPrefsManager.GetUnlockedLevel();
		if (unlockedLevel == 0) unlockedLevel = 3;
		Debug.Log("Loading level " + unlockedLevel);
		LoadLevel(unlockedLevel);
	}
	
	public void QuitRequest() 
	{
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
