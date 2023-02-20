using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    /// <summary>
    /// This is the GameManager class.
    /// Do not access this class. This is only a class to make the hierarchy prettier.
    /// Any modification of this class may lead to potential crash.
    /// </summary>
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

	private void Exit()	{
        Application.Quit();
	}

	private void TogglePause() {
        if (!isPaused) {
            InputManager.Instance.TogglePause();
            LevelManager.Instance.PauseScreen();
            
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

