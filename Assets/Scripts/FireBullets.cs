using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField] public float bulletForce;

    private float chasingSpeed;
    private float lifeTime;

    private Transform target;
    private Rigidbody2D rb2d;
    private SpriteRenderer targetSprite;

    private Color nearDeadColor;
    private MeshRenderer txt;
    void Start()
    {
        txt = GetComponentInChildren<MeshRenderer>();
        lifeTime = Random.Range(5f, 13f);

        rb2d = GetComponent<Rigidbody2D>();

        txt.enabled = false;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetSprite = GetComponent<SpriteRenderer>();

        Destroy(gameObject, lifeTime);
        rb2d.AddForce(transform.up *bulletForce * Time.deltaTime);

        chasingSpeed = Random.Range(0.3f, 1.5f); // each bullet has different traversal speed

        // get current rbg color
        nearDeadColor = targetSprite.color;

        InvokeRepeating("pulsingColor", lifeTime - 3, 0.7f);
        Invoke("displayScore", lifeTime - 0.5f);
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            // if lifetime  ran out, add point 
            ScoreSystem.instance.bulletExplodedPoint();
        }       
    }

    private void FixedUpdate()
    {
        // keep heading toward target which is player
        Vector2 direction = target.position;
        rb2d.transform.position = Vector2.MoveTowards(transform.position, direction, chasingSpeed * Time.deltaTime);
    }

    void pulsingColor()
    {
        nearDeadColor.a = Mathf.Lerp(1f, 0.86f, 2f);
        targetSprite.color = nearDeadColor;
        Invoke("pulsingColorAlter", 0.3f);
    }

    void pulsingColorAlter()
    {
        nearDeadColor.a = Mathf.Lerp(0.86f, 1f, 2f);
        targetSprite.color = nearDeadColor;
    }


    // display score number when bullets explode
    void displayScore()
    {
        txt.enabled = true;
    }


}
