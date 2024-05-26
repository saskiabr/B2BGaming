using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class EndPanelController : MonoBehaviour
{   

    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] TMP_Text endText;
    [SerializeField] TMP_Text buttonText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text missesText;

	void OnEnable()
	{
		Timer.OnGameEnded += OnGameEnded;
	}

	void OnDisable()
	{
		Timer.OnGameEnded -= OnGameEnded;
	}

	void OnGameEnded()
	{

        // If we were in training, for either walking or aiming:
        if(ExperimentSettings.IsTrainingPhase)
        {
            endText.text = "End of training,\nAre you ready?";
            buttonText.text = "TEST";
        }
        else if(ExperimentSettings.IsWalkingTask) // This means we were in the walking task
        {
            endText.text = "End of the test!";
            scoreText.text = $"Score: {DestCounter.Score.ToString("0")}";
            buttonText.text = "CONTINUE";
        }
        else // This means we were in the aiming task
        {
            endText.text = "End of the test!";
            scoreText.text = $"Score: {ScoreCounter.Score.ToString("0")}";
            missesText.text = $"Misses: {MissCounter.Misses.ToString("0")}";
            buttonText.text = "CONTINUE";
        }

        // Activate the end panel and allow the user to interact
        canvasGroup.alpha = 1f;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
        Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

    public void RestartButton(){

        ScoreCounter.Score = 0;
        MissCounter.Misses = 0;
        DestCounter.Score = 0;

        ExperimentSettings.PassedLevels++;

        if(ExperimentSettings.PassedLevels == 4) // In this case the game is done, so we reset it and return to the main menu
        { 
            ExperimentSettings.IsTrainingPhase = true;
            ExperimentSettings.PassedLevels = 0;
            SceneManager.LoadScene("MainMenu");
        }
        else if(ExperimentSettings.IsTrainingPhase)
        {
            ExperimentSettings.IsTrainingPhase = false;
            
            if(ExperimentSettings.IsWalkingTask){ // We need to go to the walking test
                SceneManager.LoadScene("WalkTest");
            }else{
                SceneManager.LoadScene("AimTest"); // We need to go to the aim test
            }
        }
        else // We have just finished a test, meaning we need to switch to the training of the other
        { 
            ExperimentSettings.IsTrainingPhase = true;

            if(ExperimentSettings.IsWalkingTask){
                ExperimentSettings.IsWalkingTask = false;
                SceneManager.LoadScene("AimTest");
            }else{
                ExperimentSettings.IsWalkingTask = true;
                SceneManager.LoadScene("WalkTest");
            }
        }        
    }
}
