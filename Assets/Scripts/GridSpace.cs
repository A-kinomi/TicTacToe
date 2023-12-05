using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
   

    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;

        gameController.EndTurn();
    }


    private GameController gameController;
 

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }
}
