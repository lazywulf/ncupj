using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathFunc;

namespace Utility
{
	public static class MoveCal
	{
		#region BASIC_CALCULATIONS
		public static void RandSpeed(IMovable movable, float speedVar)
		{
			movable.Speed *= UnityEngine.Random.Range(1 - speedVar, 1 + speedVar);
		}

		public static void RandAngle(IMovable movable, float angleVar)
		{
			movable.Rotation *= UnityEngine.Random.Range(1 - angleVar, 1 + angleVar);
		}



		public static Vector2 RotateSpeedVector(Vector2 speed, float rotation)
		{
			return Quaternion.Euler(0f, 0f, rotation) * speed;
		}

		public static Vector2 RotateAccelerationVector(Vector2 acceleration, float rotation)
		{
			return Quaternion.Euler(0f, 0f, rotation) * acceleration;
		}

		public static void AlignSpeedWithRotation(IMovable movable)
		{
			movable.Speed = RotateSpeedVector(movable.Speed, movable.Rotation);
		}
		#endregion

		#region MOVEMENT_TEMPLATES
		public static void Move(IMovable movable)
		{
			movable.Position += movable.Speed * Time.deltaTime;
			movable.Speed += movable.Acceleration * Time.deltaTime;
		}

		public static void MoveByMath(IMovable movable, ParaFunc func)
		{
			movable.Position = func.Step();
		}
		#endregion

	}
}
