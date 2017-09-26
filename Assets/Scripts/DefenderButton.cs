using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DefenderButton : MonoBehaviour {

	public static GameObject selectedDefender;
	public GameObject linkedDefender;

	private DefenderButton[] buttons;

	void Start()
	{
		buttons = GameObject.FindObjectsOfType<DefenderButton>();
		SetLinkedDefenderCostDisplay(GetLinkedDefenderPrice());
	}
	
	private int GetLinkedDefenderPrice()
	{
		return linkedDefender.GetComponent<Defender>().price;
	}
	
	private void SetLinkedDefenderCostDisplay(int cost)
	{
		transform.FindChild("Cost").GetComponent<Text>().text = cost.ToString();
	}

	void OnMouseDown()
	{
		if (GameObject.FindObjectOfType<LevelProgress>().IsLevelCompleted()) return;
	
		UnselectDefenders();
		SelectDefender();
	}

	void UnselectDefenders()
	{
		foreach (var button in buttons) {
			button.GetComponent<SpriteRenderer>().color = Color.black;
		}
	}

	void SelectDefender()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = linkedDefender;
	}
}
