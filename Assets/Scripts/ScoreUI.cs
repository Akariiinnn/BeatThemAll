using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;

    private int score;

    public void Start()
    {
        score = 0;
        label.text = "Score: 0";
    }

    public void AddScorePoint()
    {
        score++;
        label.text = $"Score: {score}";
    }
}
