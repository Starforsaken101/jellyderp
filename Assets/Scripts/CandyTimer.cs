using UnityEngine;
using System.Collections;

public class CandyTimer : MonoBehaviour {
	public delegate void GameStateHandler(GameController.GAME_STATES state);

	public GameObject m_txtTimer;
	private float _counter;
	private float _maxTime;

	private bool _isStopped = true;

	public event GameStateHandler StopGame;

	// Use this for initialization
	void Start () {
		_counter = _maxTime;
	}

	public void SetMaxTime(float timeLimit)
	{
		_maxTime = timeLimit;
		UpdateText();
		_counter = _maxTime;
		_isStopped = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_isStopped)
		{
			if (_counter < 0)
			{
				m_txtTimer.GetComponent<GUIText>().text = "GAME OVER";
				StopGame(GameController.GAME_STATES.GAME_LOSE);
				StopTimer();
			}
			else
			{
				_counter -= Time.deltaTime;
				UpdateText();
			}
		}
	}

	public void StopTimer()
	{
		_isStopped = true;
	}

	private void UpdateText()
	{
		int minutes = (int) _counter / 60;
		int seconds = (int) _counter % 60;

		string timeLeft = string.Format("{0:00}:{1:00}", minutes, seconds);
		m_txtTimer.GetComponent<GUIText>().text = timeLeft;
	}
}
