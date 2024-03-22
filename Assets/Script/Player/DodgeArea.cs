using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeArea : MonoBehaviour
{
	GameObject player;

	[SerializeField] private int focusReward;
	[SerializeField] private int focusLoss;

	private void OnEnable()
	{
		player = this.transform.parent.gameObject;

	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Enemy"))
		{
			player.GetComponent<Player>().Focus += focusReward;
		}
	}
}
