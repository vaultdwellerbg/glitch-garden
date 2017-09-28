using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public void Spawn(GameObject attacker)
	{	
		Quaternion defaultRotation = Quaternion.identity;
		GameObject newAttacker = Instantiate (attacker, transform.position, defaultRotation) as GameObject;
		newAttacker.transform.SetParent(transform);
	}
}
