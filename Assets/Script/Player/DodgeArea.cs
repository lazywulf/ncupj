using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeArea : MonoBehaviour
{
	GameObject playerObj;
	Player player;

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
		if (collider.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("Hit!");
			player.Focus += player.focusReward;

		}
	}

	private void Update()
	{
		transform.localPosition = Vector2.zero;
	}
}
