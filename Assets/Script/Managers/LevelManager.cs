using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager> {
    /// <summary>

    /// </summary>

    // var
    private static List<string> levels = new List<string>();
    
    // public methods
    /// Scene loading
    public void NextScene() {
        SceneManager.LoadSceneAsync("TestingGameScene2");
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName);
    }

    // Toggle pause
    public void PauseScreen() {
    }

    public void UnpauseScreen(){
         SceneManager.UnloadSceneAsync("PauseScreen");
		//SceneManager.UnloadScene("PauseScreen");
	}
}


