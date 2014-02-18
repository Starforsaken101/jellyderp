using UnityEngine;
using System.Collections;

public class CandyProgressBar : MonoBehaviour {
	private Rect _progressRect;
	private Texture2D tex;

	private int _maxWidth = 100;
	private int _maxHeight = 302;

	// Use this for initialization
	void Start () {
		tex = new Texture2D(_maxWidth, _maxHeight);
		Color fillColor = Color.yellow;
		Color[] colorArray = tex.GetPixels ();

		for (int i = 0; i < colorArray.Length; i++)
		{
			colorArray[i] = fillColor;
		}

		tex.SetPixels (colorArray);
		tex.Apply();

		Sprite sprite = new Sprite();
		_progressRect = new Rect(0, 0, tex.width, 0);
		sprite = Sprite.Create(tex, _progressRect, new Vector2(0, 0));

		this.GetComponent<SpriteRenderer>().sprite = sprite;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void IncreaseProgress(float percentage)
	{
		_progressRect.height = percentage * _maxHeight;
		this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, _progressRect, new Vector2(0, 0));
	}
}
