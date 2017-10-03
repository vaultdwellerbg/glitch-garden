using UnityEngine;
using System.Collections;

public class Timer {

	private float time = 0;
	private float timeout = 0;
	private float shortTimeout = 0;
	
	public Timer(float timeout, float shortTimeout)
	{
		this.timeout = timeout; 
		this.shortTimeout = shortTimeout;
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
	
	public void SetShortTimeout()
	{
		timeout = shortTimeout;
	}
}
