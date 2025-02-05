using UnityEngine;
using System;
using TMPro;
using UnityEngine.WSA;

public class ScoreManager : MonoBehaviour
{

    public String pointTo;

    public int score = 0;

    public BallController ball;
    
    public TextMeshProUGUI scoreText;

    public ScoreManager side;
    
    void OnTriggerEnter(Collider other)
    {
        score++;
        scoreText.text = $"{score}";
        
        Debug.Log(pointTo +" side SCORED!!! " + score);

        if (score == 11)
        {
            Debug.Log("Game Over, " + pointTo + " Paddle WINS!!! ");
            score = 0;
            scoreText.text = $"{score}";
            side.resetScore();
        }
        
        ball.Launch();
    }

    public void resetScore()
    {
        score = 0;
        scoreText.text = $"{score}";
    }
    
}
