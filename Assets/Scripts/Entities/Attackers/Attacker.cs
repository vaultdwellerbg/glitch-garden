using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Health))]
public class Attacker : MonoBehaviour {

	private float speed;
	private GameObject currentTarget;
	private Animator animator;
	
	void Start () 
	{
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		myRigidBody.isKinematic = true;
		animator = gameObject.GetComponent<Animator>();
	}
	
	void Update () 
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
	
	public void SetSpeed(float speed)
	{
		this.speed = speed;
	}
	
	public void StrikeCurrentTarget(float damage)
	{
		Health targetHealth = currentTarget.GetComponent<Health>();
		targetHealth.DealDamage(damage);
		
		if (targetHealth.value <= 0)
		{
			StopAttack();
		}
	}
	
	private void StopAttack()
	{
		animator.SetBool("isAttacking", false);
	}	
	
	public void Attack(GameObject obj)
	{
		currentTarget = obj;
		animator.SetBool("isAttacking", true);
	}
}
