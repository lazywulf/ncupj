using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpReward : Reward
{
	private void Start()
	{
		Acceleration = new Vector2(0f, -10f);
	}
}
