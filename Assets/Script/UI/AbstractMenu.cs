using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractMenu : MonoBehaviour 
{
	private GameObject @object;
	private Button[] buttons;
	private Image[] images;

	protected void Awake()
	{  
		@object = gameObject;
		Debug.Log(@object.name);
		buttons = @object.GetComponentsInChildren<Button>();
		images = @object.GetComponentsInChildren<Image>();
	}

	protected Button FindByName(string name) {
		foreach (var button in buttons) {
			if (button.name == "buttons") {
				return button;
			}
		}
		Debug.Log("Button not found.");
		return null;
	}

	public void SetActive(bool active) {
		@object.SetActive(active);
	}
}
