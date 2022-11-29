using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour {
    /*

    */
    // var
    private static InputManager _instance;

    private bool inputLock = false;

    private static bool upKeyHoldDown = false;
    private static bool downKeyHoldDown = false;
    private static bool leftKeyHoldDown = false;
    private static bool rightKeyHoldDown = false;
    private static bool fireKeyHoldDown = false;
    private static bool slowKeyHoldDown = false;
    private static bool bombKeyPressed = false;

    // singleton
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


    // Overrided MonoBehaviour methods
    private void Awake() {
        if (_instance == null) {
            _instance = this;
        }
    }


    private void Update() {
        if (!inputLock) {
            if (Input.GetKey(KeyCode.UpArrow)) upKeyHoldDown = true;
            else upKeyHoldDown = false;
            if (Input.GetKey(KeyCode.DownArrow)) downKeyHoldDown = true;
            else downKeyHoldDown = false;
            if (Input.GetKey(KeyCode.LeftArrow)) leftKeyHoldDown = true;
            else leftKeyHoldDown = false;
            if (Input.GetKey(KeyCode.RightArrow)) rightKeyHoldDown = true;
            else rightKeyHoldDown = false;
            if (Input.GetKey(KeyCode.Z)) fireKeyHoldDown = true;
            else fireKeyHoldDown = false;
            if (Input.GetKeyDown(KeyCode.X)) bombKeyPressed = true;
            else bombKeyPressed = false;
            if (Input.GetKey(KeyCode.LeftShift)) slowKeyHoldDown = true;
            else slowKeyHoldDown = false;
        }
        else {
            upKeyHoldDown = false;
            downKeyHoldDown = false;
            leftKeyHoldDown = false;
            rightKeyHoldDown = false;
            fireKeyHoldDown = false;
            bombKeyPressed = false;
            slowKeyHoldDown = false;
        }
    }


    // public methods
    public void TogglePause() {
        /* 
            Toggle pause.
            When puased, user input will be locked.
         */
        if (!inputLock) inputLock = true;
        else inputLock = false;
    }


    public bool Up(){
        return upKeyHoldDown;
    }

    
    public bool Down(){
        return downKeyHoldDown;
    }


    public bool Left(){
        return leftKeyHoldDown;
    }


    public bool Right(){
        return rightKeyHoldDown;
    }


    public bool Fire(){
        return fireKeyHoldDown;
    }


    public bool Slow(){
        return slowKeyHoldDown;
    }


    public bool Bomb(){
        return bombKeyPressed;
    }


    public bool Pause() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            return true;
        }
        return false;
    }
}
