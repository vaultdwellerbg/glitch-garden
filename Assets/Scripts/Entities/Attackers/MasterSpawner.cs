using UnityEngine;
using System.Collections;

public class MasterSpawner : MonoBehaviour {

	public GameObject[] attackerTypes;
	
	private Timer[] timers;
	private Spawner[] spawners;
	private LevelProgress levelProgress;
	private bool finalAttackStarted = false;
	
	private const int FINAL_ATTACK_TIMEOUT = 1;

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
			timers [i] = new Timer (attackerTypes[i]);
		}
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
		if (levelProgress.GetRemainingTime() < 40 && !finalAttackStarted)
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
			timers[i].SetTimeout(FINAL_ATTACK_TIMEOUT);
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
