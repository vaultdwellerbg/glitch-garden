using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Health))]
public class Attacker : MonoBehaviour {

	[Tooltip("Number of seconds between creating new attacker")]
	public float secondsToShow;
	public float finalWaveSecondsToShow;

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
		
		if (!currentTarget)
		{
			StopAttack();
		}		
	}
	
	public void SetSpeed(float speed)
	{
		this.speed = speed;
	}
	
	public void StrikeCurrentTarget(float damage)
	{	
		if (!currentTarget) return;
			
		Health targetHealth = currentTarget.GetComponent<Health>();
		targetHealth.DealDamage(damage);
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
