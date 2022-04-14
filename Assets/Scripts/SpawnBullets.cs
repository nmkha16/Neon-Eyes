using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    public List<GameObject> bullets;
    public List<Transform> spawnPoint;
    float timer1,timer2;
    void Start()
    {
        timer1 = Random.Range(10f, 30f);
        timer2 = Random.Range(1f, 7f);
        // each monster has different timing on shooting bullets
        
    }

    private void Update()
    {
        timer1-=Time.deltaTime;
        timer2-=Time.deltaTime;
        if (timer1 <= 0)
        {
            spawnSpecialBullet();
            timer1 = Random.Range(8f, 30f);
        }
        if (timer2 <= 0)
        {
            spawnBullet();
            timer2 = Random.Range(2f, 8f);
        }

    }

    void spawnBullet()
    {
        Instantiate(bullets[0], spawnPoint[0].position, spawnPoint[0].rotation);
    }

    void spawnSpecialBullet()
    {
        Instantiate(bullets[1], spawnPoint[0].position, spawnPoint[0].rotation);
        Instantiate(bullets[1], spawnPoint[1].position, spawnPoint[1].rotation);
        Instantiate(bullets[1], spawnPoint[2].position, spawnPoint[2].rotation);
    }

}
