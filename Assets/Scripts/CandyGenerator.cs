using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// TODO: Eventually make these into "real" colors with better names
public class CandyGenerator: MonoBehaviour {
	public static readonly string CANDY_RED = "CANDY RED";
	public static readonly string CANDY_BLUE = "CANDY BLUE";
	public static readonly string CANDY_GREEN = "CANDY GREEN";
	public static readonly string CANDY_ORANGE = "CANDY ORANGE";
	public static readonly string CANDY_PURPLE = "CANDY PURPLE";

	public Sprite m_sprCandyRed;
	public Sprite m_sprCandyBlue;
	public Sprite m_sprCandyGreen;
	public Sprite m_sprCandyOrange;
	public Sprite m_sprCandyPurple;

	private static Dictionary<string, Sprite> _candyDico;
	private static Dictionary<string, int> _availableColors;

	public void LoadCandy()
	{
		_candyDico = new Dictionary<string, Sprite>();
		_availableColors = new Dictionary<string, int>();

		// Add all of the above colors
		_candyDico.Add(CANDY_RED, m_sprCandyRed);
		_candyDico.Add(CANDY_BLUE, m_sprCandyBlue);
		_candyDico.Add(CANDY_GREEN, m_sprCandyGreen);
		_candyDico.Add(CANDY_ORANGE, m_sprCandyOrange);
		_candyDico.Add (CANDY_PURPLE, m_sprCandyPurple);
	}

	public static Sprite GetSpriteByColor(string color)
	{
		return _candyDico[color];
	}

	public static string GetRandomCandyType()
	{
		List<string> keys = Enumerable.ToList(_candyDico.Keys);
		return keys[Random.Range(0, keys.Count)];
	}

	public static void ResetAvailableColors()
	{
		_availableColors = new Dictionary<string, int>();
	}

	public void AddAvailableColorAmount(string color, int amount)
	{
		if (!_availableColors.ContainsKey(color))
			_availableColors.Add(color, amount);
		else
			_availableColors[color] += amount;
	}

	public void RemoveAvailableColorAmount(string color, int amount)
	{
		_availableColors[color] -= amount;
	}

	public static int GetAvailableColorAmount(string color)
	{
		return _availableColors[color];
	}
}
