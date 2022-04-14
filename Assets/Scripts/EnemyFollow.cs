using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb2d;
    public float speed;
    private float rotationSpeed;
    // Start is called before the first frame update
    private Vector2 direction;
    void Start()
    {
        target= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 9,true); // allow enemies and bullets pass thru each other
        Physics2D.IgnoreLayerCollision(9,9,true); // allow bullets pass thru each other
        Physics2D.IgnoreLayerCollision(9, 10, true); // allow bullets pass thru shield
        Physics2D.IgnoreLayerCollision(8, 10, true); // allow monster pass thru shield

        // set random speed for each monster
        speed = Random.Range(0.2f, 2.2f);
        rotationSpeed = Random.Range(1f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.position;
       
        if (Vector2.Distance(transform.position,target.position)> 2)
        {
           
            rb2d.transform.position = Vector2.MoveTowards(transform.position,direction,speed*Time.deltaTime);

        }
    }

    private void FixedUpdate()
    {
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
        rb2d.transform.rotation = Quaternion.Slerp(rb2d.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
