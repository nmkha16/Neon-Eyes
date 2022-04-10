using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance { get; private set; }
    private int score;
    private float timer; // update score every 1s;
    public TMP_Text scoreHUD;
    void Start()
    {
        score = 0;
        instance = this;
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            survivePoint();
            timer = 1f;
            // update score hud
            scoreHUD.text = score.ToString();
        }
       
    }

    void survivePoint()
    {
        // every second survival increase score 22 scores
        score += 22;
    }

    public void bulletExplodedPoint()
    {
        score += 3;
    }


    public int getScore()
    {
        return score;
    }

    public void nearDodgePoint()
    {
        score += 150;
    }
}
