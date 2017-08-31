using UnityEngine;
using System.Collections;

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
		Debug.Log("Target has been hit for " + damage + " damage.");
	}
	
	public void Attack(GameObject obj)
	{
		currentTarget = obj;
		animator.SetBool("isAttacking", true);
	}
}
