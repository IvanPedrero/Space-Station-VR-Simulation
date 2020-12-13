using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamingScore : MonoBehaviour {

    public Text scoreText;

    public int highScore;

    public void SetScore(int newScore)
    {
        //If the score is higher...
        if(newScore >= highScore)
        {
            highScore = newScore;
            scoreText.text = highScore.ToString();
        }
    }
}
