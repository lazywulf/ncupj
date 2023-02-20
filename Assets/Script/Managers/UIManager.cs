using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour, IEventListener
{
	private static EventManager _instance;

	public static EventManager Instance
	{
		get
		{
			if (_instance != null)
			{
				return _instance;
			}
			else
			{
				Debug.Log("Null EventManager.");
				return null;
			}
		}
	}

	private void OnEnable()
	{
		
	}

	private void OnDisable()
	{

	}

	public void OnEventTrigger()
	{
		throw new System.NotImplementedException();
	}
}
