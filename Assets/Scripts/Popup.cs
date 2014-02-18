using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

	void Awake()
	{
		this.gameObject.SetActive (false);
	}

	public virtual void ShowPopup()
	{
		this.gameObject.SetActive(true);
	}

	public virtual void HidePopup()
	{
		this.gameObject.SetActive(false);
	}
}
