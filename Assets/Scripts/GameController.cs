using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
//Let's check it later.
public class Player
    //whay before GameController class?
{
    public Image panel;
    public TMP_Text text;
    public Button button;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{
    public List<TMP_Text> buttonList;
    // I need to review waht is "List"

    private string playerSide;
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;

    private int moveCount;
    public GameObject restartButton;
    //public GameObject aiueo; OK, in Unity, the first letter changes to capital.

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    public GameObject startInfo;

    public void Start()
    {
        SetGameControllerReferenceOnButtons();
        //playerSide = "X";

        gameOverPanel.SetActive(false);

        moveCount = 0;

        restartButton.SetActive(false);

        //SetPlayerColors(playerX, playerO);

        ///SetPlayerButtons(false);
    }

    public void SetGameControllerReferenceOnButtons()
    {
        //I should learn several ways to call loop again...
        for (int i = 0; i < buttonList.Count; i++)
            //Count? what is this?
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
                //???????????????????????????????????????
        }
    }

  

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        //Debug.Log("EndTurn is not implemented!");
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
            //check ==, &&! what do they mean?
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }


        else if (moveCount >= 9)
        {
            /*
            gameOverPanel.SetActive(true);
            gameOverText.text = "It's a draw!";
            */
            //SetGameOverText("It's a draw!");
            GameOver("draw");
        }

        //To change the player foe next tuern.
        else
        {
            ChangeSlides();
        }

    }

    void ChangeSlides()
    {
        if (playerSide == "X")
        {
            playerSide = "O";
            SetPlayerColors(playerO, playerX);
        }

        else
        {
            playerSide = "X";
            SetPlayerColors(playerX, playerO);
        }

    }

    void GameOver(string winningPlayer)
    {
        /*
        for(int i= 0; i < buttonList.Count; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
            //I need to understand bool more.
        }
        */
        SetBoardInteractable(false);

        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a Draw!");
            SetPlayerColorsInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }

        /*
        gameOverPanel.SetActive(true);
        gameOverText.text = playerSide + " Wins!";
        */
        //SetGameOverText(playerSide + " Wins!");

        restartButton.SetActive(true);
    }

   

    void SetGameOverText(string value)
        //I haven't understanded well the meaning inside the ().
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value; //what is this meaning?
    }

    public void RestartGame()
    {
        //playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);

        //SetBoardInteractable(true);
        for (int i = 0; i < buttonList.Count; i++)
        {
            //buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";

            restartButton.SetActive(false);
        }

        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        startInfo.SetActive(true);
        //SetPlayerColors(playerX, playerO);
    }

    void SetBoardInteractable(bool toggle)
    { 
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if(playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }

        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        startInfo.SetActive(false);
    }

    void SetPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
        //toggle?
    }

    void SetPlayerColorsInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
}
