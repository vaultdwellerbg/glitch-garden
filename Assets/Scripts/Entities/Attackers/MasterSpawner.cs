using UnityEngine;
using System.Collections;

public class MasterSpawner : MonoBehaviour {

	public GameObject[] attackerTypes;
	
	private Timer[] timers;
	private GameObject[] activeSpawners;

	void Start()
	{
		InitTimers();	
		SetActiveSpawners ();
	}

	void InitTimers()
	{
		timers = new Timer[attackerTypes.Length];
		for (int i = 0; i < attackerTypes.Length; i++) {
			timers [i] = new Timer (attackerTypes [i]);
		}
	}

	void SetActiveSpawners ()
	{
		activeSpawners = new GameObject[3];
		activeSpawners[0] = transform.GetChild(1).gameObject;
		activeSpawners[1] = transform.GetChild(2).gameObject;
		activeSpawners[2] = transform.GetChild(3).gameObject;
	}
	
	void Update()
	{
		for (int i = 0; i < attackerTypes.Length; i++) {
			if (timers[i].IsTimeToSpawn(Time.deltaTime))
			{
				SpawnAttacker(attackerTypes[i]);
			}
		}
	}
	
	
	void SpawnAttacker(GameObject attacker)
	{
		int randomIndex = Random.Range(0, activeSpawners.Length - 1);
		activeSpawners[randomIndex].GetComponent<Spawner>().Spawn(attacker);
	}
}
