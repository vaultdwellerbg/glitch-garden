using UnityEngine;
using System.Collections;

public class SunTrophy : MonoBehaviour {

	private StarsController starsController;
	
	void Start()
	{
		starsController = GameObject.FindObjectOfType<StarsController>();
	}

	public void AddStars(int amount)
	{
		starsController.AddStars(amount);
	}
}
