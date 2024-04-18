using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour, IMovable
{
	public UnityAction moveAction;
	public UnityEvent move;

	public Vector2 Speed { get; set; }
	public Vector2 Acceleration { get; set; }
	public float Rotation
	{
		get { return transform.eulerAngles.z; }
		set { transform.Rotate(0f, 0f, value); }
	}
	public Vector2 Position
	{
		get { return transform.position; }
		set { transform.position = value; }
	}

	private void Init()
	{
		Speed = Vector2.zero;
		Acceleration = Vector2.zero;
	}

	private void OnEnable()
	{
		Init();
	}
}
