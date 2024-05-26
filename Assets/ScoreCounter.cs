using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public static int Score;

    void OnEnable()
    {
        Target.OnTargetHit += IncrementScore;
    }

    void OnDisable()
    {
        Target.OnTargetHit -= IncrementScore;
    }

    void IncrementScore()
    {
        Score++;
        text.text = $"Score: {Score}";
    }
}
