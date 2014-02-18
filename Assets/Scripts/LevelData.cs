using UnityEngine;
using System.Collections;

public class LevelData {
	private float _timeLimit;
	private int _numCandies;
	private float _announcerTime;

	public LevelData(float timeLimit, int numCandies, float announcerTime)
	{
		_timeLimit = timeLimit;
		_numCandies = numCandies;
		_announcerTime = announcerTime;
	}

	public float AnnouncerTime
	{
		get
		{
			return _announcerTime;
		}
	}

	public int NumCandies
	{
		get
		{
			return _numCandies;
		}
	}

	public float TimeLimit
	{
		get
		{
			return _timeLimit;
		}
	}
}
