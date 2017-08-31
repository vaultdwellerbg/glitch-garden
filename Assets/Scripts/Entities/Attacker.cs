using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)]
	public float speed;

	void Start () 
	{
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		myRigidBody.isKinematic = true;
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
}
