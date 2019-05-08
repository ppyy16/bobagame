using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : MonoBehaviour
{

    public Text textscore;
    public int ballvalue;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    private void OnTriggerEnter2D()
    {
        score += ballvalue;
        print(score);
        UpdateScore();
    }

    void UpdateScore()
    {
        textscore.text = "Score: " + score;

    }
}
