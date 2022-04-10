using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearDodge : MonoBehaviour
{
    public Transform player;
    public MeshRenderer dodgePoint;
    void Start()
    {
        dodgePoint.enabled = false;
        Physics2D.IgnoreLayerCollision(6, 11, true); // ignore collision between player and near dodge area
        Physics2D.IgnoreLayerCollision(6, 10, true); // ignore collision between player and player's shield

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("HERE");
        if (collision.gameObject.tag == "Bullets")
        {
            dodgePoint.enabled=true;
            ScoreSystem.instance.nearDodgePoint();
            Invoke("hideDodgePoint", 0.4f);
        }
    }

    private void hideDodgePoint()
    {
        dodgePoint.enabled = false;
    }
}
