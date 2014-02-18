using UnityEngine;
using System.Collections;

public class ButtonEventDispatcher : MonoBehaviour {
	public delegate void ButtonEventHandler();
	
	public event ButtonEventHandler MouseDown;
	public event ButtonEventHandler MouseUp;
	public event ButtonEventHandler MouseEnter;

	void OnMouseDown()
	{
		if (MouseDown != null)
			MouseDown();
	}
	
	void OnMouseUp()
	{
		if (MouseUp != null)
			MouseUp();
	}
	
	void OnMouseEnter()
	{
		if (MouseEnter != null)
			MouseEnter();
	}
}
