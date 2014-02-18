using UnityEngine;
using System.Collections;

public class EndGamePopup : Popup {
	public delegate void EventReset();
	public delegate void EventQuitGame();
	public delegate void EventContinue();

	public GameObject m_btnRetryContinue;
	public GameObject m_btnQuit;
	public GameObject m_txtHeader;

	public event EventReset ResetGame;
	public event EventQuitGame QuitGame;
	public event EventContinue ContinueToNextLevel;

	private enum END_STATE { WIN, LOSE, ULTIMATE_WIN };
	private END_STATE _endState;

	public void SetGameWin()
	{
		_endState = END_STATE.WIN;
	}

	public void SetGameLose()
	{
		_endState = EndGamePopup.END_STATE.LOSE;
	}

	public void SetUltimateWin()
	{
		_endState = EndGamePopup.END_STATE.ULTIMATE_WIN;
	}

	public override void ShowPopup ()
	{
		base.ShowPopup ();

		switch (_endState)
		{
			case END_STATE.WIN:
				m_txtHeader.GetComponent<GUIText>().text = "YOU WIN!";
				m_btnRetryContinue.GetComponent<Button>().SetText("Continue");
				m_btnRetryContinue.GetComponent<ButtonEventDispatcher>().MouseUp += HandleContinueToNextLevel;
				break;
			case END_STATE.LOSE:
				m_txtHeader.GetComponent<GUIText>().text = "lul u lose";
				m_btnRetryContinue.GetComponent<Button>().SetText ("Restart");
				m_btnRetryContinue.GetComponent<ButtonEventDispatcher>().MouseUp += HandleRetryLevel;
				break;
			case END_STATE.ULTIMATE_WIN:
				m_txtHeader.GetComponent<GUIText>().text = "YOU ARE MASTER";
				m_btnRetryContinue.GetComponent<Button>().SetText ("Restart");
				m_btnRetryContinue.GetComponent<ButtonEventDispatcher>().MouseUp += HandleRetryLevel;
				break;
		}

		m_btnQuit.GetComponent<ButtonEventDispatcher>().MouseUp += HandleQuitGame;
	}

	public override void HidePopup ()
	{
		m_btnRetryContinue.GetComponent<ButtonEventDispatcher>().MouseUp -= HandleRetryLevel;
		m_btnRetryContinue.GetComponent<ButtonEventDispatcher>().MouseUp -= HandleContinueToNextLevel;
		base.HidePopup ();
	}

	private void HandleRetryLevel()
	{
		if (ResetGame != null)
			ResetGame();

		HidePopup();
	}

	private void HandleQuitGame()
	{
		if (QuitGame != null)
			QuitGame();

		HidePopup();
	}

	private void HandleContinueToNextLevel()
	{
		if (ContinueToNextLevel != null)
			ContinueToNextLevel();

		HidePopup();
	}
}
