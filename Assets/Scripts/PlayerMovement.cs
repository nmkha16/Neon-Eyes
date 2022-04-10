using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [Header("Movement")]
    [SerializeField] public float moveSpeed;
    [SerializeField] public float rotationSpeed = 400f;
    public float thrust;
    [SerializeField] public bool isBoost;

    private TrailRenderer trail;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        isBoost = true;
        trail.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        boost();
    }


    void boost()
    {
        // speed boost will further increase speed
        if (Input.GetKeyDown(KeyCode.LeftShift) && isBoost)
        {
            trail.enabled = true;
            CameraAction.instance.doShake(0.2f);
            CameraAction.instance.zoomIn();
            moveSpeed += 100f;
            trail.time += 0.06f;
            rb2d.AddForce(transform.up * thrust*Time.deltaTime, ForceMode2D.Force);
            isBoost = false;
            Invoke("exitCooldown", 3); // set speed thrust cooldown 3 seconds;
        }
    }

    private void FixedUpdate()
    {
        //rotate
        if (direction != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            rb2d.transform.rotation = Quaternion.Slerp(rb2d.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void move()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rb2d.velocity = direction.normalized * moveSpeed*Time.deltaTime;

        
    }

    void exitCooldown()
    {
        //reset speed only if speed boost is used
        moveSpeed -= 100f;
        isBoost = true;
        trail.enabled = false;
    }


}
