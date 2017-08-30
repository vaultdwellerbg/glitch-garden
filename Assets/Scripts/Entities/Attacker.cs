using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)]
	public float walkSpeed;

	void Start () 
	{
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		myRigidBody.isKinematic = true;
	}
	
	void Update () 
	{
		transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
	}
}
