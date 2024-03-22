//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//public class SquareSprite : MonoBehaviour
//{
//	[SerializeField] private EventListener listener;
//	[SerializeField] private GenericGameEvent @event;

//	private void OnEnable()
//	{
//		listener?.Subscribe(Test);
//	}

//	private void OnDisable()
//	{
//		listener?.Unsubscribe();
//	}

//	private void Update()
//	{
//		if (InputManager.instance.Bomb())
//		{
//			@event.Raise();
//		}
//	}

//	void OnMouseDown()
//	{
//		LevelManager.instance.LoadScene("TestingGameScene2");
//		Debug.Log("Sprite Pressed.");
//	}

//	public void Test()
//	{
//		Debug.Log("Event Triggered.");
//	}
//}
