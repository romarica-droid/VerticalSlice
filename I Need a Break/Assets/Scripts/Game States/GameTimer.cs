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
    private float curValue = 90f;

    public delegate void LoseGame();
    public event LoseGame loseGame;

    void Start()
    {
        gameWon = false;
        startTimer = false;
        GameControllerLocator.Instance.Npc.startUp += TimerStart;
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
}
