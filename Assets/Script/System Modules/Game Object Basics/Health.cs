using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
	private int hp;
	private int maxHp = 1;

	public UnityAction onDeathAction;
	public UnityEvent onDeath;
	public UnityAction onSpawnAction;
	public UnityEvent onSpawn;


	public int Hp
	{
		get { return hp; }
		set
		{
			hp = (value >= 0 || value <= MaxHealth) ? value : hp;
			if (hp <= 0)
			{
				onDeath?.Invoke();
				this.gameObject.SetActive(false);
			}
		}
	}

	public int MaxHealth
	{
		get { return maxHp; }
		set { maxHp = value; }
	}

	private void Init()
	{
		hp = maxHp;
	}

	private void OnEnable()
	{
		Init();
		onSpawn?.Invoke();
	}

}
