using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public void UpdateScoreValue(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHealthValue(float health)
    {
        healthText.text = health.ToString();

    }

    private void Start()
    {
        FindObjectOfType<ScoreManager>().OnScoreChanged.AddListener(UpdateScoreValue);
    }
}
