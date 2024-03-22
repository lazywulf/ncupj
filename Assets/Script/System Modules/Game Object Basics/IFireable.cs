using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFireable
{
	public float FireRate { get; set; }
	public int BulletQuantity { get; set; }
	public float FireArc { get; set; }
	public float AngleVar { get; set; }
	public float SpeedVar { get; set; }
}
