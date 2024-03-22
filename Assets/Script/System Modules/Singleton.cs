using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Component
{
    private static T _instance;

    protected Singleton() { }

    public static T Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                Debug.LogError(string.Format("Null {0}.", typeof(T).FullName));
                return null;
            }
        }
    }

    // Overrided MonoBehaviour methods
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
    }
}
