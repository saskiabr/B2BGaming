using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Action OnGameEnded;
    public static bool GameEnded { get ; private set; }

    // The amount of time the game takes, editable from unity
    [SerializeField] float trainingTime = 5f;
    [SerializeField] float testTime = 5f;
    private float gameTime;

    Image timerBar;

    float timeLeft;

    void Start()
    {
        Time.timeScale = 1;
        GameEnded = false;
        timerBar = GetComponent<Image>();
        if(ExperimentSettings.IsTrainingPhase){
            gameTime = trainingTime;
        }else{
            gameTime = testTime;
        }
        timeLeft = gameTime;
    }

    void Update()
    {
        if(timeLeft > 0)
        {   
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / gameTime;
        } else {
            GameEnded = true;
            OnGameEnded?.Invoke();
            Time.timeScale = 0;
        }
    }
}
