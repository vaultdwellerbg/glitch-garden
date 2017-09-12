using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerTypes;
	
	void Update()
	{
		foreach (var attacker in attackerTypes) {
			if(IsTimeToSpawn(attacker))
			{
				Spawn(attacker);
			}
		}
	}
	
	private bool IsTimeToSpawn(GameObject attacker)
	{	
		float secondsToShow = attacker.GetComponent<Attacker>().secondsToShow;	
		float spawnsPerSecond = 1 / secondsToShow;
		if (Time.deltaTime > spawnsPerSecond)
		{
			Debug.LogWarning("Spawn rate capped by frame rate.");
		}	
		
		int spawnersCount = GameObject.FindObjectsOfType<Spawner>().Length;
		float threshold = spawnsPerSecond * Time.deltaTime / spawnersCount;
		return Random.value < threshold;
	}

	private void Spawn(GameObject attacker)
	{	
		Quaternion defaultRotation = Quaternion.identity;
		GameObject newAttacker = Instantiate (attacker, transform.position, defaultRotation) as GameObject;
		newAttacker.transform.SetParent(transform);
	}
}
