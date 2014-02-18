using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	private ButtonEventDispatcher _eventDispatcher;

	public Sprite m_buttonDownSprite;
	public Sprite m_buttonUpSprite;
	public GameObject m_txt;

	void Awake()
	{
		_eventDispatcher = this.gameObject.GetComponent<ButtonEventDispatcher>();
	}

	// Use this for initialization
	void Start () {
		_eventDispatcher.MouseDown += OnMouseDown;
		_eventDispatcher.MouseUp += OnMouseUp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetText(string text)
	{
		m_txt.GetComponent<GUIText>().text = text;
	}

	private void OnMouseDown()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = m_buttonDownSprite;
	}

	private void OnMouseUp()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = m_buttonUpSprite;
	}
}
