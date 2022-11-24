using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSprite : MonoBehaviour {
    
    void Awake() {
    }

    void Start() {

    }


    void Update() {

    }

    void OnMouseDown() {
        LevelManager.Instance.LoadScene("TestingGameScene2");
        Debug.Log("Sprite Pressed.");
    }
}
