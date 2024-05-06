using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utility;

public class Turret : MonoBehaviour, IFireable
{
	public event Action fire;

	[field: SerializeField] public float FireRate { get; set; } = 1;
	[field: SerializeField] public int BulletQuantity { get; set; } = 1;
	[field: SerializeField] public float FireArc { get; set; }
	[field: SerializeField] public float AngleVar { get; set; }
	[field: SerializeField] public float SpeedVar { get; set; }
	[SerializeField] public PoolSystem bulletPool;

	private bool firing = false;
	private bool canFire = true;

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
			fire?.Invoke();
			yield return new WaitForSecondsRealtime(1 / FireRate);
			if (!firing) break;
		}
		canFire = true;
		yield return null;
	}

	private void Update()
	{
		
		SetFire(true);
	}

}
