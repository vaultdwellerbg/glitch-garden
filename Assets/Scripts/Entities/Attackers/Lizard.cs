using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	private Attacker attacker;

	void Start() 
	{
		attacker = GetComponent<Attacker>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject colliderObject = col.gameObject;
		if (!colliderObject.GetComponent<Defender>()) return;
		
		attacker.Attack(colliderObject);
	}
	
	public void Strike()
	{
		attacker.StrikeCurrentTarget(5);
	}	
}
