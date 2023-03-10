using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SquareSprite : MonoBehaviour {
	[SerializeField] private EventListener listener;
	[SerializeField] private GameEvent @event;

	private void OnEnable()
	{
		listener?.OnEnable(Test);
	}
	
	private void OnDisable()
	{
		listener?.OnDisable();
	}

	private void Update()
	{
		if (InputManager.Instance.Bomb())
		{
			@event.Raise();
		}
	}

	void OnMouseDown() {
        LevelManager.Instance.LoadScene("TestingGameScene2");
        Debug.Log("Sprite Pressed.");
    }

	public void Test() {
		Debug.Log("Event Triggered.");
	}
}
