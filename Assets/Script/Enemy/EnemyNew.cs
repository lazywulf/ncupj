using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class EnemyNew : MonoBehaviour
{
	private void OnEnable()
	{
		Turret turret = GetComponent<Turret>();
		Movement movement = GetComponent<Movement>();
		// we can't assign methods straight as event handlers
		// we create a delegate instance here
		movement.Speed = new Vector2(0f, 5f); //TODO: FIX THIS!!!

		turret.fire += () => FireCal.DefaultFire(turret, "enbul", -30f);
		movement.move += () => MoveCal.Move(movement);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject @object = collider.gameObject;
		int hp = this.GetComponent<Health>().Hp;
		if (@object.CompareTag("Player"))
		{
			hp -= (@object.GetComponent<Bullet>()) ? @object.GetComponent<Bullet>().damage : 1;
		}
	}
}
