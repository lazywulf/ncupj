using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{

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
