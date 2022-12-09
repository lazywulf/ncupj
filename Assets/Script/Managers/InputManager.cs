using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    /// <summary>
    /// This class is to manage user inputs.
    /// InputManager is a Mono singleton, which means you only need to call "InputManager.Instance" for its instance.
    /// 
    /// Inputs will be lock under certain conditions, indicated by "inputLock" var.
    /// </summary>
    private static InputManager _instance;
    private bool inputLock = false;

    public static InputManager Instance {
        get {
            if (_instance != null) {
                return _instance;
            }
            else {
                Debug.LogError("Null InputManager.");
                return null;
            }
        }
    }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
        }
    }

    public void TogglePause() {
        if (!inputLock) inputLock = true;
        else inputLock = false;
    }

    public bool Up(){
        if (!inputLock && Input.GetKeyDown(KeyCode.UpArrow)) {
            return true;
        }
        return false;
    }
    
    public bool Down(){
        if (!inputLock && Input.GetKeyDown(KeyCode.DownArrow)) {
            return true;
        }
        return false;
    }

    public bool Left(){
        if (!inputLock && Input.GetKeyDown(KeyCode.LeftArrow)) {
            return true;
        }
        return false;
    }

    public bool Right(){
        if (!inputLock && Input.GetKeyDown(KeyCode.RightArrow)) {
            return true;
        }
        return false;
    }

    public bool Fire(){
        if (!inputLock && Input.GetKeyDown(KeyCode.Z)) {
            return true;
        }
        return false;
    }

    public bool Bomb(){
        if (!inputLock && Input.GetKeyDown(KeyCode.B)) {
            return true;
        }
        return false;
    }

    public bool Slow(){
        if (!inputLock && Input.GetKeyDown(KeyCode.LeftShift)) {
            return true;
        }
        return false;
    }

    public bool Pause() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            return true;
        }
        return false;
    }
}

