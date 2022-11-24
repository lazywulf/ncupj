using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    /*
        This is the game manager, a manager class for scene control and game progress control.
        This class is attach to an invisable game object, LevelManager.
        `LevelManager.Instance` is used to access the public method of this class.
    */
    // var
    private static LevelManager _instance;
    private static List<string> levels = new List<string>();

    // singleton
    public static LevelManager Instance {
        get {
            if (_instance != null) {
                return _instance;
            }
            else {
                Debug.LogError("Null LevelManager.");
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
        SceneManager.LoadSceneAsync("PauseScreen", LoadSceneMode.Additive);
    }

    public void UnpauseScreen(){
        SceneManager.UnloadSceneAsync("PauseScreen");
    }
}


