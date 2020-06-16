using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

public class GameScreenBehavior : MonoBehaviour
{

    private Transform player;
    private Transform ai;
    private Text titleText;
    private Text listText;
    private Transform menuPointer;
    private int playerScore;
    private int aiScore;
    private int playerChoice;
    private int aiChoice;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        aiScore = 0;
        player = this.gameObject.transform.GetChild(1);
        ai = this.gameObject.transform.GetChild(0);
        titleText = this.gameObject.GetComponentInChildren(typeof(Text)) as Text;
        titleText.text = playerScore + "          -          " + aiScore;
        listText = this.gameObject.transform.GetChild(2).GetChild(1).gameObject.GetComponent<Text>();
        listText.text = "Rock\n\nPaper\n\nScissors";
        menuPointer = this.gameObject.transform.GetChild(3);
        menuPointer.position = new Vector3(-2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MenuPointerFunction();
    }

    void MenuPointerFunction()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (menuPointer.position.y == 0)
            {
                movePointer(-2);
            }
            else
            {
                movePointer(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (menuPointer.position.y == -2)
            {
                movePointer(2);
            }
            else
            {
                movePointer(-1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (menuPointer.position.y)
            {
                case 0:
                    playerChoice = 0;
                    break;
                case -1:
                    playerChoice = 1;
                    break;
                case -2:
                    playerChoice = 2;
                    break;
            }
            listText.text = "";
            System.Random random = new System.Random();
            aiChoice = random.Next(0, 3);
            UnityEngine.Debug.Log(aiChoice);
            showChoices();
            switch (playerChoice)
            {
                case 0:
                    switch (aiChoice)
                    {
                        case 0:
                            print("tie");
                            break;
                        case 1:
                            print("loss");
                            aiScore++;
                            break;
                        case 2:
                            print("win");
                            playerScore++;
                            break;
                    }
                    break;
                case 1:
                    switch (aiChoice)
                    {
                        case 0:
                            print("win");
                            playerScore++;
                            break;
                        case 1:
                            print("tie");
                            break;
                        case 2:
                            print("loss");
                            aiScore++;
                            break;
                    }
                    break;
                case 2:
                    switch (aiChoice)
                    {
                        case 0:
                            print("loss");
                            aiScore++;
                            break;
                        case 1:
                            print("win");
                            playerScore++;
                            break;
                        case 2:
                            print("tie");
                            break;
                    }
                    break;
            }
            listText.text = "Rock\n\nPaper\n\nScissors";
            titleText.text = playerScore + "          -          " + aiScore;
        }
    }

    void movePointer(int i)
    {
        menuPointer.position += new Vector3(0, i, 0);
    }

    void showChoices()
    {
        Thread.Sleep(1000);
        
    }

}
