using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float value;

	public void DealDamage (float damage) {
		value -= damage;
		if (value <= 0)
		{
			DestroyOwner();
		}
	}
	
	public void DestroyOwner()
	{
		DestroyObject(gameObject);
	}
}
