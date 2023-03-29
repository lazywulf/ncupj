using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuAction : ActionScript
{
	private GameManager gameManager = GameManager.Instance;
	public void Resume() {
		if (gameManager.IsPaused()) {
			gameManager.TogglePause();
		}
	}

	public void Quit() {
		gameManager?.Exit();
	}
}
