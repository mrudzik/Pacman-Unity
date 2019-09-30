using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public PacMan_Map		ourMap;
	
	public RectTransform	menuUI;
	public RectTransform 	gameUI;
	public RectTransform 	loseUI;
	public RectTransform 	winUI;

	private void Start()
	{
		ourMap.playerData.ShowHighScore();
	}

	private void 	HideAllUI()
	{
		winUI.gameObject.SetActive(false);
		loseUI.gameObject.SetActive(false);
		menuUI.gameObject.SetActive(false);
		gameUI.gameObject.SetActive(false);
	}
	
	public void     StartNewGame()
	{
		ourMap.StartAGame();
		HideAllUI();
		gameUI.gameObject.SetActive(true);
	}
	
	public void 	ExitButton()
	{
		Application.Quit();
	}
	
	public void 	ToMainMenu()
	{
		HideAllUI();
		ourMap.KillAllTiles();
		ourMap.playerData.ShowHighScore();
		menuUI.gameObject.SetActive(true);
	}
}
