using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
	public Vector2 Speed { get; set; }
	public Vector2 Acceleration { get; set; }
	public float Rotation { get; set; }
	public Vector2 Position { get; set; }
}
