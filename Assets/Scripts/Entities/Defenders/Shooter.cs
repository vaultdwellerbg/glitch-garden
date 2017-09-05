using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, projectileParent;
	
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
