using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] public GameObject shieldPickUp;
    public GameObject quad;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        spawnObject(enemy,PlayerPrefs.GetInt("difficulty"));
        
        timer = 10f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            spawnObject(shieldPickUp, 1);
            timer = Random.Range(5f, 12f);
        }
    }

    private void spawnObject(GameObject objectToSpawn, int n)
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenX, screenY;

        Vector2 pos;

        for(int i = 0;i < n; i++)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX,screenY);
            Instantiate(objectToSpawn, pos, objectToSpawn.transform.rotation);
        }
    }
}
