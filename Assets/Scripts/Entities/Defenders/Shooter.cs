using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, projectileParent;
	private bool reloading = false;
	private float firingRate = 2f;
	private float elapsedTime;
	
	private void Fire()
	{
		if (reloading) return;		
		CreateNewProjectile ();
		reloading = true;
	}

	void CreateNewProjectile ()
	{
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.SetParent (projectileParent.transform);
		newProjectile.transform.position = transform.FindChild("Gun").transform.position;
	}
	
	void Update()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= firingRate)
		{
			elapsedTime = 0;
			reloading = false;
		}
	}
}
