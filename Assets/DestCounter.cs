using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestCounter : MonoBehaviour
{
    // Count the destinations reached

    [SerializeField] TMP_Text text;
    public static int Score;

    void OnEnable()
    {
        DestinationTarget.OnTargetHit += IncrementScore;
    }

    void OnDisable()
    {
        DestinationTarget.OnTargetHit -= IncrementScore;
    }

    void IncrementScore()
    {
        Score++;
        text.text = $"Score: {Score}";
    }
}
