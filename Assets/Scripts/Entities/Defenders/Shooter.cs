using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner currentLaneAttackersSpawner;
	private const string PROJECTILES_PARENT_NAME = "Projectiles";
			
	private void Start()
	{
		InitializeProjectileParent();	
		SetCurrentLaneAttackersSpawner();
		animator = GetComponent<Animator>();
	}

	void InitializeProjectileParent ()
	{
		projectileParent = GameObject.Find(PROJECTILES_PARENT_NAME);
		if (!projectileParent) {
			projectileParent = new GameObject(PROJECTILES_PARENT_NAME);
		}
	}
	
	private void SetCurrentLaneAttackersSpawner()
	{
		currentLaneAttackersSpawner = FindCurrentLaneAttackersSpawner();
		if (!currentLaneAttackersSpawner) 
		{
			Debug.LogWarning("No attackers spawner on lane.");
		}
		
	}

	private Spawner FindCurrentLaneAttackersSpawner()
	{
		GameObject spawnersContainer = GameObject.Find("Spawners");
		foreach (Transform child in spawnersContainer.transform) {
			Spawner spawner = child.GetComponent<Spawner>();
			if (spawner.transform.position.y == transform.position.y) {
				return spawner;
			}
		}
		return null;
	}
	
	void Update()
	{
		animator.SetBool("isAttacking", IsAttackerApproaching());
	}
	
	private bool IsAttackerApproaching()
	{
		return LineHasAttackers() && LineHasAttackerBeforeDefender();
	}
	
	private bool LineHasAttackers()
	{
		return currentLaneAttackersSpawner.transform.childCount > 0;
	}	
	
	private bool LineHasAttackerBeforeDefender()
	{
		foreach (Transform attackerObject in currentLaneAttackersSpawner.transform) {
			if (attackerObject.transform.position.x > transform.position.x)
			{
				return true;
			}
		}	
		return false;
	}
	
	private void Fire()
	{	
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		PositionProjectile(newProjectile);
	}
	
	private void PositionProjectile(GameObject projectile)
	{
		projectile.transform.SetParent (projectileParent.transform);
		projectile.transform.position = transform.FindChild("Gun").transform.position;	
	}

}
