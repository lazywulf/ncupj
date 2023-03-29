using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    /// <summary>
    /// This class is to manage user inputs.
    /// InputManager is a Mono singleton, which means you only need to call "InputManager.Instance" for its instance.
    /// 
    /// Inputs will be lock under certain conditions, indicated by "inputLock" var.
    /// </summary>
    private static InputManager _instance;
    private bool inputLock = false;

    private InputManager() { }

    public static InputManager Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                Debug.LogError("Null InputManager.");
                return null;
            }
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void TogglePause()
    {
        inputLock = !inputLock;
    }

    public bool Up()
    {
        return !inputLock && Input.GetKey(KeyCode.UpArrow);
    }

    public bool Down()
    {
        return !inputLock && Input.GetKey(KeyCode.DownArrow);
    }

    public bool Left()
    {
        return !inputLock && Input.GetKey(KeyCode.LeftArrow);
    }

    public bool Right()
    {
        return !inputLock && Input.GetKey(KeyCode.RightArrow);
    }

    public bool Fire()
    {
        return !inputLock && Input.GetKey(KeyCode.Z);
    }

    public bool Bomb()
    {
        return !inputLock && Input.GetKeyDown(KeyCode.B);
    }

    public bool Slow()
    {
        return !inputLock && Input.GetKey(KeyCode.LeftShift);
    }

    public bool Pause()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }
}
