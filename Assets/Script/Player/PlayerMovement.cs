using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
	Rigidbody2D rb;
	private bool sl = false;

	[SerializeField] float speedScalar = 10.0f;
	[SerializeField] float slowingFactor = 0.4f;

	[SerializeField] EventListenerVector2 movement;
	[SerializeField] EventListener slow;


	public Vector2 Speed { get; set; }
	public Vector2 Acceleration { get; set; }
	public float Rotation { get; set; }
	public Vector2 Position { get; set; }

	private void OnEnable()
	{
		slow.Subscribe(Slow);
		movement.Subscribe(Move);
		rb = GetComponent<Rigidbody2D>();
		transform.position = GameArea.Instance.SpawnPoint;
	}

	private void Slow() 
	{
		sl = !sl;
		rb.velocity *= (sl)? slowingFactor: 1 / slowingFactor;
	}

	private void Move(Vector2 input)
	{
		Speed = input * speedScalar * ((sl)? slowingFactor: 1.0f);
		rb.velocity = Speed;
		StartCoroutine(PositionLimitCoroutine());
	}

	IEnumerator PositionLimitCoroutine()
	{
		while (true)
		{
			transform.position = GameArea.Instance.MoveablePosition(transform.position);
			yield return null;
		}
	}
}
