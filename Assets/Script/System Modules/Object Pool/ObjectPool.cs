using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPool
{
	[SerializeField] public string poolName;
	[SerializeField] public GameObject prefab;
	[SerializeField] public int size = 1;
	Transform parent;
	Queue<GameObject> queue;

	public void Init(Transform t)
	{
		parent = t;
		GameObject temp = null;
		queue = new();
		for (int i = 0; i < size; i++) 
		{
			temp = Copy();
			temp.transform.parent = parent;
			queue.Enqueue(temp);
		}
	}

	private GameObject Copy()
	{
		var copy = GameObject.Instantiate(prefab);
		copy.transform.parent = parent;
		copy.SetActive(false);
		return copy;
	}

	private GameObject Available()
	{
		GameObject availableObject;
		if (queue.Count > 0 && !queue.Peek().activeSelf) 
		{
			availableObject = queue.Dequeue();
		}
		else 
		{
			availableObject = Copy();
			size++;
		}
		queue.Enqueue(availableObject);
		return availableObject;
	}

	public GameObject Prepare() 
	{
		GameObject prep = Available();
		prep.SetActive(true);
		return prep;
	}

	public GameObject Prepare(Transform t)
	{
		GameObject prep = Available();
		prep.transform.position = t.position;
		prep.transform.rotation = t.rotation;
		prep.transform.localScale = t.localScale;
		prep.SetActive(true);
		return prep;
	}
}
