using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class EventListener : MonoBehaviour
{
	/// <summary>
	/// EventListener not Finished.
	/// </summary>
	public GameEvent gameEvent;
	public UnityEvent onEventTriggered;

	public EventListener(GameEvent eventName) {
		gameEvent = eventName;
	}

	private void OnEnable() {
		gameEvent.AddListener(this);
	}

	private void OnDisable() {
		gameEvent.RemoveListenter(this);
	}

	public void OnEventTrigger() {
		onEventTriggered.Invoke();
	}
}
