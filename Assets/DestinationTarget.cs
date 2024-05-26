using System;
using UnityEngine;

public class DestinationTarget : MonoBehaviour
{
    public static Action OnTargetHit;

    void Start(){
        RandomizePosition();
    }

    private void OnTriggerEnter(Collider other)
    {   
        // If a player walks into the collider
        if (other.CompareTag("Player"))
        {
            if(!ExperimentSettings.IsTrainingPhase){
                OnTargetHit?.Invoke();
            }
            RandomizePosition();
        }
    }

    void RandomizePosition(){
        transform.position = DesTargetBounds.Instance.GetRandomPosition();
    }
}
