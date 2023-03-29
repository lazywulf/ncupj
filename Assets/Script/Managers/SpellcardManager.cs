using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellcardManager : MonoBehaviour
{
    private static SpellcardManager _instance;

    private SpellcardManager() { }

    public static SpellcardManager Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                Debug.LogError("Null SpellcardManager.");
                return null;
            }
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

	public void OnLevelWasLoaded()
	{
	
	}
}
