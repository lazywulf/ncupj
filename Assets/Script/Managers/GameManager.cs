using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager> {
    private bool paused = false;
    private float originalTimeScale = 1;

    private static List<string> scences = new List<string>();


    private void Update() {
        if (InputManager.Instance.Pause()) TogglePause();
    }

    private void FixedUpdate() {
        
    }

    // methods
	public void Exit()	{
        Application.Quit();
	}

	public void TogglePause() {
        
    }

    public bool IsPaused() {
        return paused;
	}



    // public methods
    /// Scene loading
    public void NextScene()
    {
        SceneManager.LoadSceneAsync("TestingGameScene2");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    // Toggle pause
    public void PauseScreen()
    {
    }

    public void UnpauseScreen()
    {
        SceneManager.UnloadSceneAsync("PauseScreen");
        //SceneManager.UnloadScene("PauseScreen");
    }
}

