using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform CameraHolder;
    // sensitivity is now editable from the unity UI!
    [SerializeField] float sensitivity = 1;
    float verticalLookRotation;

    // void Start()
    // {   
    //     // For when playing on a computer
    //     //
    //     // // Hide the cursor --> for comp game, idk ab relevance once its turned into a mobile game
    //     // Cursor.visible = false;
    //     // // Lock it to the center of the screen
    //     // Cursor.lockState = CursorLockMode.Locked;
    // }

    void Update()
    {   
        if(Timer.GameEnded){ return; }

        // If the screen is being touched
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Calculate the different in touch between now and the last screen
            Vector2 touchDelta = touch.deltaPosition;

            // Horizontal rotation (around Y axis)
            transform.Rotate(Vector3.up * touchDelta.x * sensitivity * Time.deltaTime);

            // Vertical rotation
            if(ExperimentSettings.IsControlCondition)
            {
                // Normal vertical control
                verticalLookRotation -= touchDelta.y * sensitivity * Time.deltaTime;
            } 
            else 
            {
                verticalLookRotation += touchDelta.y * sensitivity * Time.deltaTime;
            }

            // Clamp vertical rotation to avoid flipping
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
            CameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
        }
        
        // The following code is for looking around on a computer
        //
        // // This allows looking left an right
        // transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        // if(ExperimentSettings.IsControlCondition)
        // {
        //     // Normal vertical control
        //     verticalLookRotation -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        // } 
        // else 
        // {
        //     verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        // }

        // // Limit rotation so the player can not do a 360
        // verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        // CameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }
}
