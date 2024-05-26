using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int scenePicker;
    public void Start()
    {
        scenePicker = Random.Range(0,10);
    }

    // This button should take participants to the control condition of the game
    public void ControlButton()
    {   
        ExperimentSettings.IsControlCondition = true;
        ExperimentSettings.IsTrainingPhase = true;

        // Randomly decide whether to start with the walking or the aiming task
        if(scenePicker<5){
            ExperimentSettings.IsWalkingTask = true;
            SceneManager.LoadScene("WalkTest");
        } else {
            ExperimentSettings.IsWalkingTask = false;
            SceneManager.LoadScene("AimTest");    
        }
        
    }

    // This button should take participants to the experimental condition of the game
    public void ExperimentalButton()
    {
        ExperimentSettings.IsControlCondition = false;
        ExperimentSettings.IsTrainingPhase = true;

        // Randomly decide whether to start with the walking or the aiming task
        if(scenePicker<5){
            ExperimentSettings.IsWalkingTask = true;
            SceneManager.LoadScene("WalkTest");
        } else {
            ExperimentSettings.IsWalkingTask = false;
            SceneManager.LoadScene("AimTest");    
        }    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
