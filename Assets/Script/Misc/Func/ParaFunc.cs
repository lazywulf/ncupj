using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathFunc 
{ 
	public class ParaFunc
	{
		BaseFunc xFunc;
		BaseFunc yFunc;


		public ParaFunc(BaseFunc x, BaseFunc y)
		{
			xFunc = x;
			yFunc = y;
		}

		public Vector2 f(float t)
		{
			return new Vector2(xFunc.f(t), yFunc.f(t));
		}

		public Vector2 Step()
		{
			float t = Time.deltaTime;
			return new Vector2(xFunc.Step(t), yFunc.Step(t));
		}

		public Vector2 Back()
		{
			float t = Time.deltaTime;
			return new Vector2(xFunc.Back(t), yFunc.Back(t));
		}

		public Vector2 MoveFor(float time)
		{
			if (xFunc.t_p < time) return Step();
			else return f(time);
		}
	}
}
