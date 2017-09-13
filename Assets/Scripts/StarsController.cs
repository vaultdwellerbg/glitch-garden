using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarsController : MonoBehaviour {

	private int totalStars = 0;

	public void AddStars(int amount)
	{
		totalStars += amount;
		UpdateStarDisplay();
	}
	
	public void SpendStars(int amount)
	{
		int newTotalAmmount = totalStars - amount;
		if (newTotalAmmount < 0) return;
		totalStars = newTotalAmmount;
		UpdateStarDisplay();
	}	
	
	private void UpdateStarDisplay()
	{
		GetComponent<Text>().text = totalStars.ToString();
	}
}
