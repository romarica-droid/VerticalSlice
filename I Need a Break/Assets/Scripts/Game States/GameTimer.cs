using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float maxTime;

    [SerializeField] private GameObject timerDisplay;
    [SerializeField] private TMP_Text timerText;

    private bool startTimer;
    private bool gameWon;
    private float curValue;

    public delegate void LoseGame();
    public event LoseGame loseGame;

    [SerializeField] private GameObject finishDisplay;
    [SerializeField] private TMP_Text finishText;

    void Start()
    {
        curValue = maxTime;
        gameWon = false;
        startTimer = false;
        GameControllerLocator.Instance.Npc.startUp += TimerStart;
        GameControllerLocator.Instance.Ender.gameWin += GameWon;
    }

    
    void Update()
    {
        CountDown();
        UpdateText();
    }

    private void CountDown()
    {
        if(startTimer && !gameWon)
        {
            curValue -= Time.deltaTime;

            if(curValue <= 0)
            {
                loseGame?.Invoke();
                endGameLose();
                gameWon = true;
            }
        }
    }

    private void TimerStart()
    {
        Debug.Log("Game Activated");
        timerDisplay.SetActive(true);
        startTimer = true;
    }

    private void UpdateText()
    {
        timerText.text = "Time: " + (int)curValue;
    }

    private void GameWon()
    {
        gameWon = true;
        timerDisplay.SetActive(false);
    }

    private void endGameLose()
    {
        Time.timeScale = 0.0f;
        Debug.Log("The Game Has Been Lost");

        finishDisplay.SetActive(true);
        finishText.text = "You like died and lost :/";
    }
}
