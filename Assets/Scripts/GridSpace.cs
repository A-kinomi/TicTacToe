using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
    //public string playerSide;  //why it is removed?
    //question: Button, and TMP_Text are the fanction name? So are they kind of existing name not original?


    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();//the value of GetPlayerSIde?
        button.interactable = false;
        //where does "button. interactable" come from?

        gameController.EndTurn();
        //What will happne? -> "EndTurn" function in the "GameContlooler"script happens.
    }


    private GameController gameController;
    //whare is GameController from? check!!  -> the object name!
    //{}is not needed because I just named GameController = gameController 


    public void SetGameControllerReference(GameController controller)
        //SetGameContorollerReference is original name, right?????
        //What is (GameController controller)? What does it mean?
    {
        gameController = controller;
        //???why what
    }
}
