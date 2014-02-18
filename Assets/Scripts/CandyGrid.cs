using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CandyGrid : MonoBehaviour {
	public delegate void CandyBucketHandler(int amount);

	private const int GRID_SIZE_Y = 5;
	private const int GRID_SIZE_X = 5;

	private const float BLOCK_WIDTH = 1.15f;
	private const float BLOCK_HEIGHT = 1.15f;

	private GameObject[,] _grid;
	private CandyGenerator _candyGenerator;

	private List<string> _currentCandyTypes;

	private GameObject _selectedBlock;

	public GameObject m_candy;

	public event CandyBucketHandler AddCandyToBucket;

	public AudioClip mSfxFail;
	public AudioClip mSfxGood;

	private int _totalScore = 0;
	private static readonly int SCORE_PER_CLICK = 5;

	void Awake() 
	{
		_grid = new GameObject[GRID_SIZE_Y, GRID_SIZE_X];
		_candyGenerator = this.GetComponent<CandyGenerator>();
		_candyGenerator.LoadCandy();
	}

	// Use this for initialization
	void Start () {

	}

	private void AttachListeners(GameObject g)
	{
		g.GetComponent<EventDispatcher>().MouseDown += TryCollectCandy;
	}

	private void RemoveListeners(GameObject g)
	{
		g.GetComponent<EventDispatcher>().MouseDown -= TryCollectCandy;
	}

	private void TryCollectCandy(GameObject g)
	{
		string selectedCandyType = g.GetComponent<Candy>().CandyType;
		string currentCandyType = CandyAnnouncer.CurrentCandyType;

		if (selectedCandyType == currentCandyType)
		{
			AddCandyToBucket(1);

			_candyGenerator.RemoveAvailableColorAmount(selectedCandyType, 1);

			string newCandyType = selectedCandyType;
			while(newCandyType == selectedCandyType)
			{
				newCandyType = CandyGenerator.GetRandomCandyType();
			}

			g.GetComponent<Candy>().CandyType = newCandyType;
			g.GetComponent<SpriteRenderer>().sprite = CandyGenerator.GetSpriteByColor(newCandyType);
			_candyGenerator.AddAvailableColorAmount(newCandyType, 1);

			audio.PlayOneShot(mSfxGood);
		}
		else
			audio.PlayOneShot(mSfxFail);
	}

	public void DeactivateGrid()
	{
		// Take out the listeners, ya drangus
		for (int i = 0; i < GRID_SIZE_Y; i++)
		{
			for (int j = 0; j < GRID_SIZE_X; j++)
			{
				RemoveListeners(_grid[i,j]);
			}
		}
	}

	public void DestroyGrid()
	{
		for (int i = 0; i < GRID_SIZE_Y; i++)
		{
			for (int j = 0; j < GRID_SIZE_X; j++)
			{
				if (_grid[i,j] != null)
					Destroy(_grid[i,j]);
			}
		}
	}

	public void ActivateGrid()
	{
		GameObject instance;
		Vector3 position;
		float x = this.gameObject.transform.position.x;
		float y = this.gameObject.transform.position.y;
		
		for (int i = 0; i < GRID_SIZE_Y; i++)
		{
			for (int j = 0; j < GRID_SIZE_X; j++)
			{
				position = new Vector3(x, y);
				
				instance = (GameObject) Instantiate (m_candy, position, m_candy.transform.rotation);
				
				string candyType = CandyGenerator.GetRandomCandyType();
				instance.GetComponent<Candy>().CandyType = candyType;
				instance.GetComponent<SpriteRenderer>().sprite = CandyGenerator.GetSpriteByColor(candyType);
				
				_candyGenerator.AddAvailableColorAmount(candyType, 1);
				
				AttachListeners(instance);
				
				_grid[i,j] = instance;
				
				x += BLOCK_WIDTH;
			}
			x = this.gameObject.transform.position.x;
			y += BLOCK_HEIGHT;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
