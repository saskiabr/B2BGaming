using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissCounter : MonoBehaviour
{
    // [SerializeField] TMP_Text text; --> commented out as I made the text invisible
    public static int Misses;

    void OnEnable()
    {
        TargetShooter.OnTargetMissed += IncrementMisses;
    }

    void OnDisable()
    {
        TargetShooter.OnTargetMissed -= IncrementMisses;
    }

    void IncrementMisses()
    {
        Misses++;
        // text.text = $"Misses: {Misses}";
    }
}
