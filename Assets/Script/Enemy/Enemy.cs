using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Enemy: MonoBehaviour, IMovable, IDamageable, IFireable
{
	private void Awake()
	{
		hp = MaxHealth;
		Speed = Vector2.zero;
		Acceleration = Vector2.zero;
		Rotation = 0f;
		Position = Vector2.zero;

		rb = GetComponent<Rigidbody2D>();
	}

	private void OnEnable()
	{
		OnSpawn();
	}

	private void Update()
	{
		Move();
		GameArea.Instance.InBoundChecker(this.gameObject);
		SetFire(true);
	}

	private void OnDisable()
	{
		OnDeath();
		DropLoot();
	}

	#region HEALTH
	[SerializeField] private int hp;

	public int Hp
	{
		get { return hp; }
		set 
		{ 
			hp = (value >= 0 || value <= MaxHealth)? value : hp;
			if (hp <= 0)
			{
				OnDeath();
				this.gameObject.SetActive(false);
			}
		}
	}
	[field: SerializeField] public int MaxHealth { get; set; } = 7;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject @object = collider.gameObject;
		if (@object.CompareTag("Player"))
		{
			Hp -= (@object.GetComponent<Bullet>()) ? @object.GetComponent<Bullet>().damage : 1;
		}
	}

	#endregion

	#region BASIC_EVENTS
	protected virtual void OnSpawn() { }

	protected virtual void OnDeath() { }

	#endregion

	#region ATTACK
	private bool firing = false;
	private bool canFire = true;
	private bool altFiring = false;
	
	[field: SerializeField] protected PoolSystem bulletPool { get; set; }

	[field: SerializeField] public float FireRate { get; set; } = 1;
	[field: SerializeField] public int BulletQuantity { get; set; } = 1;
	[field: SerializeField] public float FireArc { get; set; }
	[field: SerializeField] public float AngleVar { get; set; }
	[field: SerializeField] public float SpeedVar { get; set; }

	protected void SetFire(bool flag)
	{
		firing = !flag;
		if (!firing && canFire)
			StartCoroutine(FireCoroutine());
	}

	private IEnumerator FireCoroutine()
	{
		canFire = false;
		while (true)
		{
			FireMethod();
			yield return new WaitForSecondsRealtime(1 / FireRate);
			if (!firing) break;
		}
		canFire = true;
		yield return null;
	}

	virtual protected void FireMethod()
	{
		FireCal.SpreadFire(this, transform, bulletPool, "enbul", -30f);
	}

	#endregion

	#region MOVEMENT
	Rigidbody2D rb;
	[SerializeField] float speedScalar = 10.0f;
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

	virtual protected void Move() { }

	#endregion

	#region LOOT
	// TODO : loot system
	[field: SerializeField] protected PoolSystem lootPool;

	virtual protected void DropLoot() 
	{
		lootPool.Get("Loot").Prepare(transform);
	}

	#endregion
}
