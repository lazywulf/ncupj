using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathFunc
{
    public class Linear : BaseFunc
    {
        private float[] term = { 0, 1 };

        public Linear(float t0, float t1)
        {
            term[0] = t0;
            term[1] = t1;
        }

        public override float f(float t)
        {
            return term[0] + term[1] * t;
        }

    }

    public class Polynomial : BaseFunc
    {
        private List<float> terms;

        public Polynomial(params float[] coefficients)
        {
            terms = new List<float>(coefficients);
        }

        public override float f(float t)
        {
            float result = 0;
            float power = 1;

            foreach (float coefficient in terms)
            {
                result += coefficient * power;
                power *= t;
            }

            return result;
        }
    }

    public class Logarithm : BaseFunc
    {
        private float baseValue;

        public Logarithm(float baseValue)
        {
            this.baseValue = baseValue;
        }

        public override float f(float t)
        {
            return Mathf.Log(t, baseValue);
        }
    }

    public class Exponential : BaseFunc
    {
        private float baseValue;

        public Exponential(float baseValue)
        {
            this.baseValue = baseValue;
        }

        public override float f(float t)
        {
            return Mathf.Pow(baseValue, t);
        }
    }

    public class SquareRoot : BaseFunc
    {
        public override float f(float t)
        {
            return Mathf.Sqrt(t);
        }
    }

    public class Power : BaseFunc
    {
        private float exponent;

        public Power(float exponent)
        {
            this.exponent = exponent;
        }

        public override float f(float t)
        {
            return Mathf.Pow(t, exponent);
        }
    }

    public class AbsoluteValue : BaseFunc
    {
        public override float f(float t)
        {
            return Mathf.Abs(t);
        }
    }

    public class Reciprocal : BaseFunc
    {
        public override float f(float t)
        {
            if (t == 0)
            {
                Debug.LogError("Cannot divide by zero.");
                return float.NaN;
            }
            return 1 / t;
        }
    }
}
