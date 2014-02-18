using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour {
	private string _candyType;

	void Awake()
	{
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		
	}

	public string CandyType
	{
		get
		{
			return _candyType;
		}
		set
		{
			_candyType = value;
		}
	}
}
