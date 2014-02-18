using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelAtlas {
	private Dictionary<int, LevelData> _levelDico;

	//--- LEVELS ---//
	private static readonly LevelData LEVEL_1 = new LevelData(60f, 25, 3f);
	private static readonly LevelData LEVEL_2 = new LevelData(60f, 50, 3f);
	private static readonly LevelData LEVEL_3 = new LevelData(60f, 50, 3f);
	private static readonly LevelData LEVEL_4 = new LevelData(60f, 75, 3f);
	private static readonly LevelData LEVEL_5 = new LevelData(75f, 100, 3f);
	private static readonly LevelData LEVEL_6 = new LevelData(45f, 50, 2f);
	private static readonly LevelData LEVEL_7 = new LevelData(45f, 65, 2f);
	private static readonly LevelData LEVEL_8 = new LevelData(45f, 75, 2f);
	private static readonly LevelData LEVEL_9 = new LevelData(30f, 30, 2f);
	private static readonly LevelData LEVEL_10 = new LevelData(30f, 45, 2f);
	private static readonly LevelData LEVEL_11 = new LevelData(30f, 60, 2f);
	private static readonly LevelData LEVEL_12 = new LevelData(30f, 75, 2f);
	private static readonly LevelData LEVEL_13 = new LevelData(30f, 85, 2f);
	private static readonly LevelData LEVEL_14 = new LevelData(30f, 95, 2f);
	private static readonly LevelData LEVEL_15 = new LevelData(30f, 100, 2f);

	private static readonly LevelAtlas _instance = new LevelAtlas();
	public static LevelAtlas Instance { get { return _instance; }}

	private static readonly int _lastLevelIndex = 15;

	public void LoadLevels()
	{
		_levelDico = new Dictionary<int, LevelData>();

		// == ADD THE LEVELS == //
		_levelDico.Add(1, LEVEL_1);
		_levelDico.Add (2, LEVEL_2);
		_levelDico.Add (3, LEVEL_3);
		_levelDico.Add (4, LEVEL_4);
		_levelDico.Add (5, LEVEL_5);
		_levelDico.Add (6, LEVEL_6);
		_levelDico.Add (7, LEVEL_7);
		_levelDico.Add (8, LEVEL_8);
		_levelDico.Add (9, LEVEL_9);
		_levelDico.Add (10, LEVEL_10);
		_levelDico.Add (11, LEVEL_11);
		_levelDico.Add (12, LEVEL_12);
		_levelDico.Add (13, LEVEL_13);
		_levelDico.Add (14, LEVEL_14);
		_levelDico.Add (15, LEVEL_15);
	}

	public bool IsLastLevel(int level)
	{
		return (_lastLevelIndex == level);
	}

	public LevelData GetLevelData(int level)
	{
		if (_levelDico.ContainsKey(level))
		{
			return _levelDico[level];
		}
		return null;
	}
}
