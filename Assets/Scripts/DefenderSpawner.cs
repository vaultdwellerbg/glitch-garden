using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject parent;
	private const string PARENT_NAME = "Defenders";

	private void Start()
	{
		parent = GameObject.Find(PARENT_NAME);
		
		if(!parent)
		{
			parent = new GameObject(PARENT_NAME);
		}
	}

	void OnMouseDown()
	{
		GameObject selectedDefender = DefenderButton.selectedDefender;
		if (selectedDefender) 
		{
			SpawnDefender(selectedDefender);
		}
	}

	private void SpawnDefender(GameObject selectedDefender)
	{
		Vector2 rawDefenderPosition = GetWorldMousePosition();
		Vector2 rounderDefenderPosition = SnapToGrid(rawDefenderPosition);
		
		Quaternion defaultRotation = Quaternion.identity;
		GameObject newDefender = Instantiate (selectedDefender, rounderDefenderPosition, defaultRotation) as GameObject;
		newDefender.transform.SetParent(parent.transform);
	}

	Vector2 GetWorldMousePosition()
	{
		return Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}

	Vector2 SnapToGrid(Vector2 rawWorldPos)
	{
		int roundX = Mathf.RoundToInt(rawWorldPos.x);
		int roundY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2(roundX, roundY);
	}
}
