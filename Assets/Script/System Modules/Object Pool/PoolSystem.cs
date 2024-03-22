 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
	[SerializeField] public ObjectPool[] pools;
	private Dictionary<string, ObjectPool> poolName = new Dictionary<string, ObjectPool>();

	private void Start()
	{
		// Cool stuff. Someone who came with this idea is a genius.
		string n = transform.name;
		foreach (ObjectPool pool in pools) 
		{
			Transform p = new GameObject(name=pool.prefab.name).transform;
			p.parent = transform;
			pool.Init(p);
			poolName.Add(pool.poolName, pool);
		}
		transform.name = n;
	}

	public ObjectPool Get(string name)
	{
#if UNITY_EDITOR
		ObjectPool tmp;
		if (!poolName.TryGetValue(name, out tmp))
		{
			Debug.Log("Key not Found");
			return tmp;
		}
#endif
		return poolName[name];
	}
}
