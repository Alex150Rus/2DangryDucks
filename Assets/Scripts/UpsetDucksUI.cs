﻿using UnityEngine;
using UnityEngine.UI;

public class UpsetDucksUI : MonoBehaviour
{
	/// <summary>
	/// Setup "Singleton" Design Pattern
	/// See http://bit.ly/Unity_Singleton
	/// </summary>
	private static UpsetDucksUI _instance;
	public static UpsetDucksUI Instance { get { return _instance; } }

	[SerializeField]
	private Text _asteroidsText;

	[SerializeField]
	private Text _scoreText;

	[SerializeField]
	private Text _resultText;

	protected void Awake()
	{
		_instance = this;
	}

	////////////////////////////////
	// 1. Here we update the texts
	////////////////////////////////	
	public void ShowAsteroids(int value)
	{
		_asteroidsText.text = string.Format("Asteroids: {0:00}", value);
	}

	public void ShowScore(int currentScore, int totalScore)
	{
		_scoreText.text = string.Format("Score: {0:00}/{1:00}", currentScore, totalScore);
	}

	public void ShowResult(bool isWin)
	{
		if (isWin)
		{
			_resultText.text = string.Format("You Win!");
		}
		else
		{
			_resultText.text = string.Format("You Lose!");
		}
	}
}
