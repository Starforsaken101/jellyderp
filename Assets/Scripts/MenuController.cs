using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public Button m_playButton;
	public Button m_creditsButton;

	public GameObject mCreditsPanel;

	// Use this for initialization
	void Start () {
		mCreditsPanel.SetActive(false);

		m_playButton.GetComponent<ButtonEventDispatcher>().MouseUp += OnPlayButtonPressed;
		m_creditsButton.GetComponent<ButtonEventDispatcher>().MouseUp += OnCreditsButtonPressed;

		LevelAtlas.Instance.LoadLevels();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCreditsButtonPressed()
	{
		if (mCreditsPanel.activeSelf == true)
			mCreditsPanel.SetActive(false);
		else
			mCreditsPanel.SetActive(true);
	}

	private void OnPlayButtonPressed()
	{
		Application.LoadLevel ("game");
	}
}
