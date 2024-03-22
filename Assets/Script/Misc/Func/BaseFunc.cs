using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MathFunc
{
	public abstract class BaseFunc
	{
		public float t_p;

		public abstract float f(float t);

		public float Step(float delta) 
		{
			t_p += delta;
			return f(t_p);
		}

		public float Back(float delta)
		{
			t_p -= delta;
			return f(t_p);
		}
	}
}
