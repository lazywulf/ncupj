using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineList : MonoBehaviour
{
	public void AddSpline()
	{
		GameObject @object = new GameObject();
		@object.AddComponent<BezierSpline>();
		@object.transform.parent = gameObject.transform;
	}

	public void DeleteSpline()
	{
		if (transform.childCount > 0)
		{
			Transform lineTransform = transform.GetChild(transform.childCount-1);
			lineTransform.parent = null;
			DestroyImmediate(lineTransform.gameObject);
		}
	}
}
