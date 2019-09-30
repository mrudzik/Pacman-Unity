using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacManData : MonoBehaviour
{
	private int points;
	[HideInInspector] public int ballsLeft;
	[HideInInspector] public PacMan_Controller ourPacman;
	[HideInInspector] public PacMan_Map ourMap;
	
	public void TakePoints(int addPoints)
	{
		points += addPoints;
		ballsLeft--;
		CheckWin();
	}



	public RectTransform 	gameUI;
	public Text 			pointText;
	
	
	public RectTransform 	winUI;
	public Text 			winScoreText;

	public RectTransform 	gameOverUI;
	public Text 			overScoreText;

	public Text 			highScoreText;
	private void RefreshUI()
	{
		pointText.text = "Points : " + points;
	}
	
	
	public void 	ShowHighScore()
	{
		int currentHighScore;
		
		currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
		highScoreText.text = "High Score : " + currentHighScore;
		
		if (points > currentHighScore)
		{
			PlayerPrefs.SetInt("HighScore", points);
			highScoreText.text = "High Score : " + points + " NEW RECORD! :P";
		}
		
	}
	
	
	public void DoWin()
	{
		gameUI.gameObject.SetActive(false);
		winUI.gameObject.SetActive(true);
		winScoreText.text = "Your Score : " + points;
		ShowHighScore();
		Destroy(ourPacman.gameObject);
	}
	
	public void DoGameOver()
	{
		gameUI.gameObject.SetActive(false);
		gameOverUI.gameObject.SetActive(true);
		overScoreText.text = "Your Score : " + points;
		ShowHighScore();
		points = 0;
		Destroy(ourPacman.gameObject);
	}
	
	private void CheckWin()
	{
		if (ballsLeft > 0)
			return;
		DoWin();
	}
	
	
	
	
	
	
	public void 	UIKeysDirection(int dir)
	{
		ourPacman.ChangeDirection(dir);
	}
	
	private void Update()
	{
		RefreshUI();
	}
}
