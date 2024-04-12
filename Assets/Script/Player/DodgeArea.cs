using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeArea : MonoBehaviour
{
	GameObject playerObj;
	Player player;

	private bool isColliding = false;

	private void OnEnable()
	{
		try
		{
			playerObj = this.transform.parent.gameObject;
			player = playerObj.GetComponent<Player>();
		}
		catch
		{
			Debug.Log("Player object Missing!");
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (isColliding) return;
		if (collider.gameObject.CompareTag("Enemy"))
		{
			isColliding = true;
			player.Focus += player.focusReward;
		}
	}

	private void Update()
	{
		transform.localPosition = Vector2.zero;
		isColliding = false;
	}
}
