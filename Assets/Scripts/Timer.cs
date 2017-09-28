using UnityEngine;
using System.Collections;

public class Timer {

	private float time = 0;
	private float timeout = 0;
	
	public Timer(GameObject attacker)
	{
		timeout = attacker.GetComponent<Attacker>().secondsToShow;
	}
	
	public bool IsTimeToSpawn(float frameTime)
	{
		time += frameTime;
		if (time > timeout)
		{
			time = 0;
			return true;
		}
		return false;
	}
	
	public void SetTimeout(float value)
	{
		timeout = value;
	}
}
