using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Bullet : MonoBehaviour, IDamageable, IMovable
{
	private void OnEnable()
	{
		Hp = MaxHealth;
		Speed = Vector2.zero;
		Acceleration = Vector2.zero;
	}

	private void Update()
	{
		Move();
		GameArea.Instance.InBoundChecker(this.gameObject);
	}

	#region DMG
	public int damage = 1;

	#endregion

	#region MOVEMENT
	public Vector2 Speed { get; set; }
	public Vector2 Acceleration { get; set; }
	public float Rotation { 
		get { return transform.eulerAngles.z; } 
		set { transform.Rotate(0f, 0f, value); } }
	public Vector2 Position { 
		get { return transform.position; } 
		set { transform.position = value; } }

	virtual protected void Move() 
	{
		MoveCal.Move(this);
	}
	#endregion

	#region BULLET_HIT_STUFF_OR_WHATEVER_THAT_MAKES_BULLET_DISAPPEAR
	private int hp;

	public int Hp
	{
		get { return hp; }
		set
		{
			hp = (value >= 0 || value <= MaxHealth) ? value : hp;
			if (hp <= 0)
			{
				OnBulletDistroy();
				this.gameObject.SetActive(false);
			}
		}
	} 
	public int MaxHealth { get; set; } = 1;

	virtual protected void OnBulletDistroy() { }

	#endregion
}
