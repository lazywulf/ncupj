using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Reward : MonoBehaviour, IMovable, IDamageable
{
	private void Awake()
	{
		Hp = MaxHealth;
		Speed = Vector2.zero;
		Acceleration = Vector2.zero;
		Rotation = 0f;
		Position = Vector2.zero;
	}

	private void Update()
	{
		Move();
		GameArea.Instance.InBoundChecker(this.gameObject);
	}

	#region HP
	private int hp;

	public int Hp
	{
		get { return hp; }
		set
		{
			hp = (value >= 0 || value <= MaxHealth) ? value : hp;
			if (hp <= 0)
			{
				OnObtain();
				this.gameObject.SetActive(false);
			}
		}
	}
	public int MaxHealth { get; set; } = 1;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			Hp--;
		}
	}

	protected virtual void OnObtain() { }

	#endregion

	#region MOVEMENT
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

	protected virtual void Move()
	{
		MoveCal.Move(this);
	}

	#endregion

}
