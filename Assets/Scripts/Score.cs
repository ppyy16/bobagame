using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : MonoBehaviour
{

    public Text textscore;
    public int ballvalue;

    public int score;

    private SpriteRenderer rend;
    private Sprite ouchface, defaultface;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        GameObject bigcup = GameObject.FindWithTag("frontcup");



        //expressions
        ouchface = Resources.Load<Sprite>("cupouch");
        defaultface = Resources.Load<Sprite>("bubbledef");

        //renderer
        rend = bigcup.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "poison")
        {
            score = score - 3;
            UpdateScore();
            rend.sprite = ouchface;
            
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
            rend.sprite = defaultface;

        }
    }


    void UpdateScore()
    {
        textscore.text = "Score: " + score;

    }
}
