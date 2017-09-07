using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	
	private GameObject projectileParent;
	private const string PROJECTILES_PARENT_NAME = "Projectiles";
			
	private void Start()
	{
		projectileParent = GameObject.Find(PROJECTILES_PARENT_NAME);
		
		if(!projectileParent)
		{
			projectileParent = new GameObject (PROJECTILES_PARENT_NAME);
		}
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
