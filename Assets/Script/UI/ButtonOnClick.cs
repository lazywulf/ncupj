using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ButtonOnClick : MonoBehaviour
{
	[SerializeField] private ActionScript action;
	public int temp;
	private Action onClickAction;

	public void OnClick() 
	{
		onClickAction?.Invoke();
	}
}
