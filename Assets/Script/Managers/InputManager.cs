using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager> , Input.IIngameActions , Input.IMenuActions
{
    /// <summary>
    /// This class is to manage user inputs.
    /// InputManager is a Mono singleton, which means you only need to call "InputManager.instance" for its instance.
    /// 
    /// Inputs will be lock under certain conditions, indicated by "inputLock" var.
    /// </summary>

    private Input inputAction;

	[SerializeField] public GameEvent bomb;
	[SerializeField] public GameEvent fire;
	[SerializeField] public GameEvent slow;
	[SerializeField] public GenericGameEvent<Vector2> move;

	[SerializeField] public GenericGameEvent<Vector2> select;
	[SerializeField] public GameEvent comfirm;
	[SerializeField] public GameEvent cancel;

	[SerializeField] public GameEvent pause;

	private void OnEnable()
	{
		inputAction = new Input();
		inputAction.Ingame.SetCallbacks(this);
		inputAction.Menu.SetCallbacks(this);
		EnablePlayerInput();
		//DisableAllInput();
	}

	private void OnDisable()
	{
		DisableAllInput();
	}

	#region GENERAL
	public void EnablePlayerInput()
	{
		inputAction.Ingame.Enable();
	}

	public void DisablePlayerInput()
	{
		inputAction.Ingame.Disable();
	}

	public void EnableMenuAction()
	{
		inputAction.Menu.Enable();
	}

	public void DisableMenuAction()
	{
		inputAction.Menu.Disable();
	}

	public void DisableAllInput()
	{
		inputAction.Disable();
	}

	#endregion

	#region IN_GAME
	public void OnBomb(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			bomb.Raise();
		}
	}

	public void OnFire(InputAction.CallbackContext context)
	{
		if (context.started || context.canceled) fire.Raise();
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		if (context.performed || context.canceled) move.Raise(context.ReadValue<Vector2>());
	}

	public void OnPause(InputAction.CallbackContext context)
	{
		if (context.started) pause.Raise();
	}

	public void OnSlow(InputAction.CallbackContext context)
	{
		if (context.started || context.canceled) slow.Raise();
	}

	#endregion

	#region MENU
	public void OnComfirm(InputAction.CallbackContext context)
	{
		if (context.started) comfirm.Raise();
	}

	public void OnCancel(InputAction.CallbackContext context)
	{
		if (context.started) comfirm.Raise();
	}

	public void OnSelection(InputAction.CallbackContext context)
	{
		if (context.performed) select.Raise(context.ReadValue<Vector2>());
	}

	#endregion



	// old stuff

	private bool inputLock = false;


	public void TogglePause()
	{
		inputLock = !inputLock;
	}

	//public bool Up()
	//{
	//	return !inputLock && Input.GetKey(KeyCode.UpArrow);
	//}

	//public bool Down()
	//{
	//	return !inputLock && Input.GetKey(KeyCode.DownArrow);
	//}

	//public bool Left()
	//{
	//	return !inputLock && Input.GetKey(KeyCode.LeftArrow);
	//}

	//public bool Right()
	//{
	//	return !inputLock && Input.GetKey(KeyCode.RightArrow);
	//}

	//public bool Fire()
	//{
	//	return !inputLock && Input.GetKey(KeyCode.Z);
	//}

	//public bool Bomb()
	//{
	//	return !inputLock && UnityEngine.Input.GetKeyDown(KeyCode.B);
	//}

	//public bool Slow()
	//{
	//	return !inputLock && Input.GetKey(KeyCode.LeftShift);
	//}

	public bool Pause()
	{
		return UnityEngine.Input.GetKeyDown(KeyCode.Escape);
	}
}
