using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHit : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public InGameMenu inGameMenu;

    public SpriteRenderer shield;
    private bool isShield;
    private int shieldHitPoint;


    public TMP_Text shieldPercent;
    public AudioSource soundEffect, deadSoundEffect;

    public SpriteRenderer drone;

    private Color hitColor, defaultColor;

    private bool isHit;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 10, true); // allow player has shield can pick up shield
        shieldPercent.text = "100%";
        isShield = true;
        shieldHitPoint = 3;
        rb2d = GetComponent<Rigidbody2D>();
        hitColor = Color.blue;
        hitColor.a = 0.9f;
        defaultColor = drone.color;
        isHit = false;
    }


    // player hits things in game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit)
        {
            if (collision.gameObject.tag == "Trap")
            {
                onHit();
            }
            
            else if (collision.gameObject.tag == "Bullets")
            {
                onHit();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                onHit();
            }
        }
        if (collision.gameObject.tag == "Pickup")
        {
            pickUp();
            Destroy(collision.gameObject);
        }
    }

    private void pickUp()
    {
        ScoreSystem.instance.awardPointOnPickUp(200f);
        shield.enabled = true;
        shieldHitPoint = 3;
        shieldPercent.text = "100%";
        isShield = true;
        shield.GetComponent<CircleCollider2D>().enabled = true;
    }

    private void onHit()
    {
        // enter immunity state
        isHit = true;

        drone.color = hitColor;

        // exit immunity state after 2s
        soundEffect.Play();
        CameraAction.instance.doShake(0.15f);
        if (isShield)
        {
            shieldHitPoint--;
            if (shieldHitPoint == 2)
            {
                shieldPercent.text = Random.Range(60, 75).ToString() + "%";
            }
            if (shieldHitPoint == 1)
            {
                shieldPercent.text = Random.Range(20, 45).ToString() + "%";
            }
            if (shieldHitPoint <= 0)
            {
                shieldPercent.text = "0%";
                isShield = false;
                shield.enabled = false;
                shield.GetComponent<CircleCollider2D>().enabled = false;
            }
            Invoke("exitImmunityState", 1f);
        }
        else
        {
            
            deadSoundEffect.Play();
            inGameMenu.endGame();
        }
    }

    void exitImmunityState()
    {
        isHit = false;
        drone.color = defaultColor;
    }
}
