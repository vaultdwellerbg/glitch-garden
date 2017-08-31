using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

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
		
		attacker.Attack(colliderObject);
	}
}
