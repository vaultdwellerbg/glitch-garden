using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	public AudioClip hitSound;

	void Update () 
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}	
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		Attacker target = collider.gameObject.GetComponent<Attacker>();
		AudioSource.PlayClipAtPoint(hitSound, transform.position);
		if (target) 
		{
			Health targetHealth = target.GetComponent<Health>();
			targetHealth.DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
