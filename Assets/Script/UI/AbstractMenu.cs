using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class AbstractMenu : MonoBehaviour 
{
	private GameObject @object;
	private readonly List<Button> buttons = new();
	private readonly List<Image> images = new();
	private Image backImg = new();

	protected void Awake()
	{  
		@object = gameObject;
		foreach (var button in @object.GetComponentsInChildren<Button>()) {
			
		}
	}

	public void SetActive(bool active) {
		@object.SetActive(active);
	}
}
