using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject m_candyGrid;
	public GameObject m_candyBucket;
	public GameObject m_candyAnnouncer;
	public GameObject m_candyTimer;
	public GameObject m_endGamePopup;
	public GameObject m_txtLevel;

	public enum GAME_STATES { GAME_START, GAME_IN_PROGRESS, GAME_WIN, GAME_LOSE };
	private GAME_STATES _currentState;

	private bool _stateChanged = false;

	private int _currentLevel;

	// Use this for initialization
	void Start () {
		AttachListeners();
		_currentLevel = 0;
		SetState (GAME_STATES.GAME_START);
	}

	private void AttachListeners()
	{
		m_candyGrid.GetComponent<CandyGrid>().AddCandyToBucket += AddCandyToBucket;
		m_candyTimer.GetComponent<CandyTimer>().StopGame += SetState;
		m_candyBucket.GetComponent<CandyBucket>().SetGameWin += SetState;

		m_endGamePopup.GetComponent<EndGamePopup>().ResetGame += ResetGame;
		m_endGamePopup.GetComponent<EndGamePopup>().ContinueToNextLevel += StartLevel;
		m_endGamePopup.GetComponent<EndGamePopup>().QuitGame += QuitGame;
	}

	private void DetachListeners()
	{
		m_candyGrid.GetComponent<CandyGrid>().AddCandyToBucket -= AddCandyToBucket;
		m_candyTimer.GetComponent<CandyTimer>().StopGame -= SetState;
		m_candyBucket.GetComponent<CandyBucket>().SetGameWin -= SetState;
		
		m_endGamePopup.GetComponent<EndGamePopup>().ResetGame -= ResetGame;
		m_endGamePopup.GetComponent<EndGamePopup>().ContinueToNextLevel -= StartLevel;
		m_endGamePopup.GetComponent<EndGamePopup>().QuitGame -= QuitGame;
	}

	private void AddCandyToBucket(int amount)
	{
		m_candyBucket.GetComponent<CandyBucket>().AddCandy(amount);
	}

	private void SetState(GAME_STATES state)
	{
		_currentState = state;
		_stateChanged = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (_stateChanged)
		{
			switch (_currentState)
			{
				case GAME_STATES.GAME_START:
					StartLevel();
					break;
				case GAME_STATES.GAME_IN_PROGRESS:
					break;
				case GAME_STATES.GAME_WIN:
					PauseGame ();

					if (LevelAtlas.Instance.IsLastLevel(_currentLevel))
					{
						m_endGamePopup.GetComponent<EndGamePopup>().SetUltimateWin();
					}
					else
					{
						m_endGamePopup.GetComponent<EndGamePopup>().SetGameWin();
					}

					m_endGamePopup.GetComponent<EndGamePopup>().ShowPopup();
					break;
				case GAME_STATES.GAME_LOSE:
					PauseGame();
					
					m_endGamePopup.GetComponent<EndGamePopup>().SetGameLose();
					m_endGamePopup.GetComponent<EndGamePopup>().ShowPopup();
					break;
			}

			_stateChanged = false;
		}
	}

	private void StartLevel()
	{
		_currentLevel += 1;
		LevelData levelData = LevelAtlas.Instance.GetLevelData(_currentLevel);

		if (levelData != null)
		{
			m_txtLevel.GetComponent<GUIText>().text = "Level " + _currentLevel.ToString();
			m_candyBucket.GetComponent<CandyBucket>().SetMaxCandies(levelData.NumCandies);
			m_candyTimer.GetComponent<CandyTimer>().SetMaxTime(levelData.TimeLimit);
			m_candyAnnouncer.GetComponent<CandyAnnouncer>().SetMaxTime(levelData.AnnouncerTime);
			SetState (GAME_STATES.GAME_IN_PROGRESS);
		}
		else
			return;

		ResetElements();
	}

	private void ResetElements()
	{
		CandyGenerator.ResetAvailableColors();
		m_candyGrid.GetComponent<CandyGrid>().DestroyGrid();
		m_candyGrid.GetComponent<CandyGrid>().ActivateGrid();
		m_candyAnnouncer.GetComponent<CandyAnnouncer>().StartAnnouncer();
		m_candyBucket.GetComponent<CandyBucket>().ResetCollectedCandies();
	}

	private void ResetGame()
	{
		_currentLevel = 0;
		StartLevel();
	}

	private void PauseGame()
	{
		m_candyGrid.GetComponent<CandyGrid>().DeactivateGrid();
		m_candyAnnouncer.GetComponent<CandyAnnouncer>().StopAnnouncer();
		m_candyTimer.GetComponent<CandyTimer>().StopTimer();
	}

	private void QuitGame()
	{
		DetachListeners();
		Application.LoadLevel ("menu");
	}
}
