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
    public AudioSource soundEffect;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 10, true); // allow player has shield can pick up shield
        shieldPercent.text = "100%";
        isShield = true;
        shieldHitPoint = 3;
        rb2d = GetComponent<Rigidbody2D>();
    }


    // player hits things in game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap" )
        {            
            onHit();
        }
        if (collision.gameObject.tag == "Pickup")
        {
            pickUp();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Bullets")
        {
            onHit();
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            onHit();
        }
    }

    private void pickUp()
    {
        shield.enabled = true;
        shieldHitPoint = 3;
        shieldPercent.text = "100%";
        isShield = true;
        shield.GetComponent<CircleCollider2D>().enabled = true;
    }

    private void onHit()
    {
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
        }
        else
        {
            inGameMenu.endGame();
        }
    }

}
