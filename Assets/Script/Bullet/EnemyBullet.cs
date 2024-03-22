using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
	#region ON_HIT_OR_CLEARED
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			Hp--;
		}

	}


	// TODO : Clear spellcard points
	[field: SerializeField] protected PoolSystem lootPool;
	[SerializeField] private int point;

	public void Clear() 
	{
		//lootPool.Get().Prepare(transform);
	}

	#endregion

}
