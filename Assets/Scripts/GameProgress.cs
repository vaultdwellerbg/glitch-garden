using UnityEngine;
using System.Collections;

public class GameProgress : MonoBehaviour {

	private const int FIRST_LEVEL_INDEX = 3;
	private const int LAST_LEVEL_INDEX = 5;

	public static void SetLevel(int index)
	{
		int levelToUnlock = (index != LAST_LEVEL_INDEX) ? index + 1 : FIRST_LEVEL_INDEX;
		PlayerPrefsManager.SetUnlockedLevel(levelToUnlock);
	}
	
	public static int GetLevel()
	{
		int unlockedLevel = PlayerPrefsManager.GetUnlockedLevel();
		if (unlockedLevel == 0) unlockedLevel = FIRST_LEVEL_INDEX;
		return unlockedLevel;	
	}
}
