//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text[] buttonList;
	private string playerSide;

	public GameObject gameOverPanel;
	public Text gameOverText;

	private int moveCount;

	void Awake()
	{
		gameOverPanel.SetActive(false);
		SetGameControllerReferenceOnButtons();
		playerSide = "X";
		moveCount = 0;
	}

	void SetGameControllerReferenceOnButtons()
	{
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList[i].GetComponentInParent<Gridspace>().SetGameControllerReference(this);
		}
	}

	public string GetPlayerSide()
	{
		return playerSide;
	}

	public void EndTurn()
	{
		moveCount++;

		if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[2].text == playerSide) 
		{
			GameOver();
		}

		if (buttonList[1].text == playerSide && buttonList[2].text == playerSide && buttonList[3].text == playerSide) 
		{
			GameOver();
		}

		if (buttonList[0].text == playerSide && buttonList[5].text == playerSide && buttonList[6].text == playerSide) 
		{
			GameOver();
		}

		if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[1].text == playerSide) 
		{
			GameOver();
		}

		if (buttonList[8].text == playerSide && buttonList[6].text == playerSide && buttonList[2].text == playerSide) 
		{
			GameOver();
		}

		if (buttonList[0].text == playerSide && buttonList[8].text == playerSide && buttonList[1].text == playerSide) 
		{
			GameOver();
		}
		if (buttonList[4].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) 
		{
			GameOver();
		}

		if (buttonList[5].text == playerSide && buttonList[8].text == playerSide && buttonList[3].text == playerSide) 
		{
			GameOver();
		}

		if (moveCount >= 9) 
		{
			SetGameOverText("It's a Draw!");
		}

		ChangeSides();
	}

	void GameOver()
	{
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList[i].GetComponentInParent<Button>().interactable = false;
		}


		SetGameOverText(playerSide + " Wins!");
	}

	void ChangeSides()
	{
		playerSide = (playerSide == "X") ? "O" : "X";
	}

	void SetGameOverText(string value)
	{
		gameOverPanel.SetActive (true);
		gameOverText.text = value;
		
	}
		
}
