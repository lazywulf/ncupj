using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	private static UIManager _instance;



	private UIManager() { }

	public static UIManager Instance
	{
		get
		{
			if (_instance != null)
			{
				return _instance;
			}
			else
			{
				Debug.Log("Null UIManager.");
				return null;
			}
		}
	}

	public void ToggleScreen(AbstractMenu menu) {
		if (menu != null) menu.SetActive(menu.isActiveAndEnabled);
	}

	private void OnEnable()
	{
		
	}

	private void OnDisable()
	{

	}
}
