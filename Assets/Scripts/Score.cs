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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "poison")
        {
            score = score - 3;
            UpdateScore();

        }
        else if (collision.gameObject.tag == "basketball")
        {
            score = score - 1;
            UpdateScore();
        }
        else if (collision.gameObject.tag == "magicpearl")
        {
            score += ballvalue * 3;
            UpdateScore();
        }

        else
        {
            score += ballvalue;
            UpdateScore();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "poison") {
    //        score = score -3;
    //        UpdateScore();
        
    //    }
    //    if (collision.gameObject.tag == "basketball") {
    //        score = score -1;
    //        UpdateScore();
    //    }
    //    if (collision.gameObject.tag == "magicpearl") {
    //        score += ballvalue * 3;
    //        UpdateScore();
    //    }


    //}

    void UpdateScore()
    {
        textscore.text = "Score: " + score;

    }
}
