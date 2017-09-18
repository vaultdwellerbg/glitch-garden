using UnityEngine;
using System.Collections;

public class Gravestone : MonoBehaviour {

	void OnTriggerStay2D(Collider2D collider)
	{
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		if (attacker)
		{
			GetComponent<Animator>().SetTrigger("isHitTrigger");
		}
	}
}
