using System;

public interface IEventListener {
	/// <summary>
	/// </summary>\
	/// 
	public void OnEnable(Action eventResponse);
	public void OnDisable();
	public void OnEventTrigger();
}
