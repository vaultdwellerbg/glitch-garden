using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Attacker attacker;
	private Animator animator;
	
	void Start () 
	{
		attacker = GetComponent<Attacker>();
		animator = GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject colliderObject = col.gameObject;
		if (!colliderObject.GetComponent<Defender>()) return;
		
		if (colliderObject.GetComponent<Gravestone>())
		{
			animator.SetTrigger("jumpTrigger");
		}
		else
		{
			attacker.Attack(colliderObject);
		}
	}
	
	public void Strike()
	{
		attacker.StrikeCurrentTarget(3);
	}
}
