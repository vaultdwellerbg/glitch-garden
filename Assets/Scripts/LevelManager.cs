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
		LoadLevel(GameProgress.GetLevel());
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
