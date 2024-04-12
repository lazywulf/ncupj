using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public abstract class Player : MonoBehaviour, IDamageable, IFireable
{
	#region EVENT
	[SerializeField] EventListener bomb;
	[SerializeField] EventListener fire;
	[SerializeField] EventListener altFire;
	[SerializeField] GameEvent death;
	#endregion

	private void OnEnable()
	{
		bomb.Subscribe(Bomb);
		fire.Subscribe(Fire);
		altFire.Subscribe(AltFire);
		
		hp = MaxHealth;
		focus = 127;
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject @object = collider.gameObject;
		if (@object.CompareTag("Enemy") && !isInvincible)
		{
			Hp -= (@object.GetComponent<Bullet>()) ? @object.GetComponent<Bullet>().damage : 1;
			Focus -= focusLoss;
			StartCoroutine(InvincibilityFrameCoroutine(0.5f));
		}
		else if (@object.CompareTag("Reward"))
		{
			
		}
	}

	#region HEALTH
	private int hp;
	private bool isInvincible = false;
	public int Hp
	{
		get { return hp; }
		set 
		{ 
			hp = (value >= 0 || value <= MaxHealth)? value : hp;
			if (hp <= 0) Death();
		}
	}
	[field: SerializeField] public int MaxHealth { get; set; } = 7;

	private IEnumerator InvincibilityFrameCoroutine(float duration)
	{
		isInvincible = true;
		yield return new WaitForSeconds(duration);
		isInvincible = false;
	}

	private void Revive()
	{
		// FIXME: Potential issue, resetting player on revive may not work properly
		this.gameObject.SetActive(true);
		InputManager.Instance.DisableMenuAction();
		InputManager.Instance.EnablePlayerInput();
		hp = (int) Math.Round(MaxHealth * 0.5);
	}

	private void Death()
	{
		death.Raise();
		InputManager.Instance.DisablePlayerInput();
		InputManager.Instance.EnableMenuAction();
		this.gameObject.SetActive(false);
	}

	#endregion

	#region ATTACK
	private bool firing = false;
	private bool canFire = true;
	private bool altFiring = false;
	
	[field: SerializeField] protected PoolSystem bulletPool { get; set; }

	[SerializeField] public int damage = 1;

	[field: SerializeField] public float FireRate { get; set; } = 1;
	[SerializeField] public float altFireRateModifier = 1;
	[field: SerializeField] public int BulletQuantity { get; set; } = 1;
	[SerializeField] public float altBulletQualityModifier = 1;
	[field: SerializeField] public float FireArc { get; set; }
	[SerializeField] public float altFireArcModifier = 1;
	[field: SerializeField] public float AngleVar { get; set; }
	[SerializeField] public float altAngleVarModifier = 1;
	[field: SerializeField] public float SpeedVar { get; set; }
	[SerializeField] public float altSpeedVarModifier = 1;

	protected IEnumerator FireCoroutine()
	{
		canFire = false;
		while (true)
		{
			if (!altFiring) NormalFire();
			else SlowFire();
			yield return new WaitForSecondsRealtime((!altFiring)? 1 / FireRate: 1 / (FireRate * altFireRateModifier));
			if (!firing) break;
		}
		canFire = true;
		yield return null;
	}

	protected virtual void NormalFire()
	{
		FireCal.DefaultFire(this, transform, bulletPool, "playerbullet1", 50f, (int)(damage * FocusToDamageModifier()));	
	}

	protected virtual void SlowFire()
	{
		FireCal.SpreadFire(this, transform, bulletPool, "playerbullet2", 30f, (int)(damage * FocusToDamageModifier()));
	}

	private void Fire() 
	{
		firing = !firing;
		if (firing && canFire)
			StartCoroutine(FireCoroutine());
	}

	private void AltFire() 
	{
		altFiring = !altFiring;
	}

	#endregion

	#region ABILITY
	[SerializeField] private int focus;

	private bool losingFocus = false;
	[SerializeField] public int focuLossInterval = 1;
	[SerializeField] public int focusReward;
	[SerializeField] public int focusLoss;

	 public int Focus 
	{
		get { return focus; }
		set 
		{
			if (value > 127) focus = 127;
			else if (value < 0) focus = 0;
			else focus = value;
		} 
	}
	public int BombCount { get; set; } = 3;

	protected abstract void Bomb();

	public void FocusLossToggle()
	{
		losingFocus = !losingFocus;
		if (losingFocus) StartCoroutine(FocusLosingCoroutine());
	}

	private IEnumerator FocusLosingCoroutine()
	{
		while (true)
		{
			Focus -= 1;
			yield return new WaitForSeconds(focuLossInterval);
			if (!losingFocus) break;
		}
		yield return null;
	}

	public float FocusToDamageModifier()
	{
		if (Focus > 128) return 4f;
		else if (Focus <= 127 && Focus >= 64) return 2f;
		else if (Focus <= 63 && Focus >= 32) return 1f;
		else if (Focus <= 31 && Focus >= 16) return 0.5f;
		else return 0.25f;
	}

	#endregion
}
