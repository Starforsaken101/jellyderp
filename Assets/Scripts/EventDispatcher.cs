using UnityEngine;
using System.Collections;

public class EventDispatcher : MonoBehaviour {
	public delegate void EventHandler(GameObject e);

	public event EventHandler MouseDown;
	public event EventHandler MouseUp;
	public event EventHandler MouseEnter;

	void OnMouseDown()
	{
		if (MouseDown != null)
			MouseDown(this.gameObject);
	}

	void OnMouseUp()
	{
		if (MouseUp != null)
			MouseUp(this.gameObject);
	}

	void OnMouseEnter()
	{
		if (MouseEnter != null)
			MouseEnter(this.gameObject);
	}
}
