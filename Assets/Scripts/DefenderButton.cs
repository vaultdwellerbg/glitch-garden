using UnityEngine;
using System.Collections;

public class DefenderButton : MonoBehaviour {

	public static GameObject selectedDefender;

	private DefenderButton[] buttons;
	
	void Start()
	{
		buttons = GameObject.FindObjectsOfType<DefenderButton>();
	}

	void OnMouseDown()
	{
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
		selectedDefender = GameObject.Find(gameObject.name);
	}
}
