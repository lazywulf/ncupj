using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSprite : MonoBehaviour {
    [SerializeField] private GameEvent @event;
    
    void Awake() {
    }

    void Start() {

    }


    void Update() {
    }

    void OnMouseDown() {
        LevelManager.Instance.LoadScene("TestingGameScene1");
        Debug.Log("Sprite Pressed.");
    }
}
