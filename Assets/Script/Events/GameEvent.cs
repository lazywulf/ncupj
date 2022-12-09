using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    /// <summary>
    /// GameEvent not finished.
    /// </summary>
    private List<EventListener> listeners = new List<EventListener>();
    
    public void TriggerEvent() {
        foreach (var listener in listeners) {
            listener.OnEventTrigger();
		}
	}

    public void AddListener(EventListener listener) {
        listeners.Add(listener);
	}

    public void RemoveListenter(EventListener listener) {
        listeners.Remove(listener);
	}
}
