using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    /*
        Please do not access this class. This is only a class to make the hierarchy prettier.
        Any modification of this class may crash the game.
    */
    // var
    private static GameManager _instance;
    
    private bool isPaused = false;
    private float originalTimeScale = 1;

    // singleton
    public static GameManager Instance {
        get {
            if (_instance != null) {
                return _instance;
            }
            else {
                Debug.LogError("Null GameManager.");
                return null;
            }
        }
    }

    // Overrided MonoBehaviour methods
    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Update() {
        if (InputManager.Instance.Pause()) TogglePause();
    }

    private void FixedUpdate() {
        
    }

    // methods
    private void GetChildByName(string childName) {
        Transform child = transform.Find(childName);
    }


    private void TogglePause() {
        if (!isPaused) {
            LevelManager.Instance.PauseScreen();
            InputManager.Instance.TogglePause();
            
            isPaused = true;
            originalTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }
        else {
            isPaused = false;
            Time.timeScale = originalTimeScale;

            LevelManager.Instance.UnpauseScreen();
            InputManager.Instance.TogglePause();
        }
    }
}

