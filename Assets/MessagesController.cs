using UnityEngine;
using System.Collections;

public class MessagesController : MonoBehaviour {

	private GameObject levelCompletedDisplay;
	private GameObject finalWaveDisplay;

	void Start () 
	{
		levelCompletedDisplay = GameObject.Find("LevelCompleted");
		levelCompletedDisplay.SetActive(false);
		finalWaveDisplay = GameObject.Find("FinalWave");
		finalWaveDisplay.SetActive(false);		
	}
	
	public void ShowLevelComplete()
	{
		levelCompletedDisplay.SetActive(true);
	}
	
	public void ShowFinalWave()
	{
		finalWaveDisplay.SetActive(true);
		Invoke("HideFinalWave", 3);	
	}
	
	private void HideFinalWave()
	{
		finalWaveDisplay.SetActive(false);
	}			
}
