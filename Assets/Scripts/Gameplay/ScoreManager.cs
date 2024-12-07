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

    [SerializeField] private List<ScoreData> allScore = new List<ScoreData>();

    [SerializeField] private ScoreData latestScore;

    private void Start()
    {

        Player playerObject = FindObjectOfType<Player>();
        playerObject.healthValue.OnDied.AddListener(RegisterScore);
        highestScore = PlayerPrefs.GetInt("HighScore");
        
        //At the start of the game
        //I will retreive the string from PlayerPrefs

        string latestScoreInJson = PlayerPrefs.GetString("LatestScore");
        
        //and try to convert it back into a ScoreData object/class
        latestScore = JsonUtility.FromJson<ScoreData>(latestScoreInJson);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RegisterScore() //when player dies
    {
        //create an object filled with info 
        latestScore = new ScoreData("Will", totalScore);

        //Convert the object (class) into a string in json format 
        string latestScoreInJson = JsonUtility.ToJson(latestScore);

        //save that sting into PlayerPrefs 
        PlayerPrefs.SetString("latestScore", latestScoreInJson);

        if (totalScore > highestScore)
        {
            //NEW HIGHSCORE
            highestScore = totalScore;
            PlayerPrefs.SetInt("HighScore", highestScore);
            //PlayerPrefs.SetString("My Name", "William");
        }
        
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
