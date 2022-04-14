using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance { get; private set; }
    private float score;
    public TMP_Text scoreHUD;
    void Start()
    {
        score = 0;
        instance = this;
    }


    private void FixedUpdate()
    {
        survivePoint();
        // update score hud
        scoreHUD.text = score.ToString("0.");
    }

    void survivePoint()
    {
        // every second survival increase score 22 scores
        score += 0.1f;
    }

    public void bulletExplodedPoint()
    {
        score += 30f;
    }

    public void awardPointOnPickUp(float point)
    {
        score += point;
    }

    public int getScore()
    {
        return Mathf.RoundToInt(score);
    }

}
