using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour {

    private int score;
    private Text scoreText;


    void Start()
    {
        score = 10;
        scoreText = transform.GetChild(1).gameObject.GetComponent<Text>();
    }


    void Update ()
    {
        
	}

    public void SetScore(int scoreToSet)
    {
        score = scoreToSet;
        scoreText.text = "" + score;
    }

    public int CheckScore
    {
        get { return score; }
    }
}
