using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using MathFunc;

public class EnemyA : Enemy
{
	ParaFunc func = new ParaFunc(
			new Linear(-18.59f, 10f),
			new Linear(-10.38f, 10f));

	// TODO : movement implementation
	protected override void Move()
	{
		//MoveCal.MoveByMath(this, func);
	}
}
