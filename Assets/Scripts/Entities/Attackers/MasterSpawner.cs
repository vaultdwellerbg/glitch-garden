using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterSpawner : MonoBehaviour {

	public GameObject[] attackerTypes;
	
	private Timer[] timers;
	private Spawner[] spawners;
	private LevelProgress levelProgress;
	private bool finalAttackStarted = false;

	void Start()
	{
		levelProgress = GameObject.FindObjectOfType<LevelProgress>();
		InitTimers();	
		InitSpawners();
	}

	void InitTimers()
	{
		timers = new Timer[attackerTypes.Length];
		for (int i = 0; i < attackerTypes.Length; i++) {
			timers[i] = CreateTimer(attackerTypes[i]);
		}
	}
	
	private Timer CreateTimer(GameObject attackerObj)
	{
		Attacker attacker = attackerObj.GetComponent<Attacker>();
		Dictionary<string, float> values = DifficultyController.GetValues(attacker.name.ToLower());
		return new Timer(values["secondsToShow"], values["finalWaveSecondsToShow"]);		
	}

	void InitSpawners()
	{
		spawners = new Spawner[transform.childCount];	
		for (int i = 0; i < transform.childCount; i++) {
			spawners[i] = transform.GetChild(i).GetComponent<Spawner>();
		}
	}
	
	void Update()
	{
		float remainingTime = levelProgress.GetRemainingTime();
	
		if (remainingTime < 5) return;
	
		if (remainingTime < 40 && !finalAttackStarted)
		{
			StartFinalAttack();
		}
		
		SpawnAttackers();
	}
	
	void StartFinalAttack()
	{		
		finalAttackStarted = true;
		GameObject.FindObjectOfType<MessagesController>().ShowFinalWave();
		for (int i = 0; i < timers.Length; i++) {
			timers[i].SetShortTimeout();
		}
	}
	
	void SpawnAttackers ()
	{
		for (int i = 0; i < attackerTypes.Length; i++) {
			if (timers [i].IsTimeToSpawn (Time.deltaTime)) {
				SpawnAttacker (attackerTypes [i]);
			}
		}
	}
	
	void SpawnAttacker(GameObject attacker)
	{
		int randomIndex = Random.Range(0, spawners.Length);
		spawners[randomIndex].Spawn(attacker);
	}
}
