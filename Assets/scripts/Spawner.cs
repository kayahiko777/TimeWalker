using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnInterval = 5.0f;
    public GameObject enemyPrefab;
    public AudioClip spawnSound;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            SpawnEnemy();

            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        GameObject spawnEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = spawnEnemy.GetComponent<Rigidbody>();

        if (spawnSound != null)
        {
            AudioSource.PlayClipAtPoint(spawnSound, transform.position);
        }
    }
}
