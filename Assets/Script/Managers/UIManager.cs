using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    // var
    private static UIManager _instance;

    // singleton 
    public static UIManager Instance {
        get {
            if (_instance != null) {
                return _instance;
            }
            else {
                Debug.LogError("Null UIManager.");
                return null;
            }
        }
    }
    
    // public method

    // Overrided MonoBehaviour methods
    void Awake() {
        _instance = this;
    }
}
