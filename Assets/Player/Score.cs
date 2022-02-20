using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;
    int score;
    public int highScore = 0;
    string highScoreKey = "HighScore";

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        score = 0;
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void GetHighScore()
    {
        if (score > highScore)
        {
            print("inside gethighscore if");
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
            highScoreText.text = highScore.ToString();
        }
    }
}
