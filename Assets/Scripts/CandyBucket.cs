using UnityEngine;
using System.Collections;

public class CandyBucket : MonoBehaviour {
	public delegate void GameWin(GameController.GAME_STATES state);

	private int _collectedCandies;
	private int _maxCandies;

	public GameObject m_txtCandyTally;
	public GameObject m_candyProgressBar;
	public event GameWin SetGameWin;

	// Use this for initialization
	void Start () {
		m_txtCandyTally.GetComponent<GUIText>().text = _collectedCandies.ToString () + " / " + _maxCandies.ToString();
	}

	public void SetMaxCandies(int maxCandies)
	{
		_maxCandies = maxCandies;
		UpdateText();
	}

	public void ResetCollectedCandies()
	{
		_collectedCandies = 0;
		UpdateText();
		m_candyProgressBar.GetComponent<CandyProgressBar>().IncreaseProgress(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void UpdateText()
	{
		m_txtCandyTally.GetComponent<GUIText>().text = _collectedCandies.ToString() + " / " + _maxCandies.ToString();
	}

	public void AddCandy(int amount)
	{
		if (_collectedCandies < _maxCandies)
		{
			_collectedCandies += amount;
			m_candyProgressBar.GetComponent<CandyProgressBar>().IncreaseProgress((float)_collectedCandies/_maxCandies);
			UpdateText();
		}

		if (_collectedCandies >= _maxCandies)
			SetGameWin(GameController.GAME_STATES.GAME_WIN);
	}
}
