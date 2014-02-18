using UnityEngine;
using System.Collections;

public class CandyAnnouncer : MonoBehaviour {
	private float _maxTime;

	private static string _currentCandyType;
	private float _counter;

	private bool _isStopped = true;

	public AudioClip mSfxSwitch;

	public GameObject m_sprCandyType;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (!_isStopped)
		{
			_counter -= Time.deltaTime;
			
			if (_counter < 0)
			{
				ChangeCandyType();
				audio.PlayOneShot(mSfxSwitch);
				_counter = _maxTime;
			}
		}
	}

	public void SetMaxTime(float time)
	{
		_maxTime = time;
	}

	public void StopAnnouncer()
	{
		_isStopped = true;
	}

	public void StartAnnouncer()
	{
		ChangeCandyType();
		_counter = _maxTime;
		_isStopped = false;
	}

	public static string CurrentCandyType
	{
		get
		{
			return _currentCandyType;
		}
	}

	private void ChangeCandyType()
	{
		_currentCandyType = CandyGenerator.GetRandomCandyType();
		bool candyOnBoard = false;
		int candyAmount = 0;

		while (!candyOnBoard)
		{
			candyAmount = CandyGenerator.GetAvailableColorAmount(_currentCandyType);

			if (candyAmount > 0)
				candyOnBoard = true;
			else
				_currentCandyType = CandyGenerator.GetRandomCandyType();
		}

		m_sprCandyType.GetComponent<SpriteRenderer>().sprite = CandyGenerator.GetSpriteByColor(_currentCandyType);
	}
}
