using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{

    public UnityEvent<int> OnScoreChanged;
    [SerializeField] private int totalScore;
    [SerializeField] private int highestScore;

    [Header("Score Values")]
    [SerializeField] private int scorePerEnemy;
    [SerializeField] private int scorePerPowerUp;
    [SerializeField] private int scorePerCoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseScore(ScoreType action)
    {
        switch(action)
        {
            case ScoreType.EnemyKilled:
                totalScore += scorePerEnemy;
                //Code that is here will be executed 
                break;

            case ScoreType.CoinCollected:
                totalScore += scorePerCoin;
                //Code that is here will be executed
                break;

            case ScoreType.PowerUpCollected:
                totalScore += scorePerPowerUp;
                //Code that is here will be executed
                break;
        }
        OnScoreChanged.Invoke(totalScore);


    }

 
}
