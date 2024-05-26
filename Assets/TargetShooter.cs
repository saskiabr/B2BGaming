using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{   

    public static Action OnTargetMissed;
    [SerializeField] Camera cam;

    public void shoot()
    {
        if(Timer.GameEnded){ return; }


        // Create a ray in the middle of the screen
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        // If our ray hits something
        if(Physics.Raycast(ray, out RaycastHit hit)){

            // Get target script on the object that we hit
            Target target = hit.collider.gameObject.GetComponent<Target>();

            if(target != null){
                target.Hit();
            }
            else if(!ExperimentSettings.IsTrainingPhase){ // The ray hit an object but it was not  target.
                    OnTargetMissed?.Invoke();
            }
        }
        else if(!ExperimentSettings.IsTrainingPhase){ // The ray hit nothing
            OnTargetMissed?.Invoke();
        }
    }
}

// When it was being used for pc:
// void shoot() --> void update()
// If statement with if mouse button down
