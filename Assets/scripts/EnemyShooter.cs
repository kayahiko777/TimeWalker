using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooter : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootingRange = 15f;
    public float moveSpeed = 3.5f;
    public float fireRate = 1.5f;
    public float bulletSpeed = 20f;

    private NavMeshAgent agent;
    private float nextFireTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindWithTag("Player");
            if (foundPlayer != null)
            {
                player = foundPlayer.transform;
            }
        }
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position,player.position);

        if (distance < shootingRange)
        {
            agent.isStopped = true;
            FacePlayer();
            Shoot();
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
    }

    void FacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction);
    }
    void Shoot()
    {
        if (Time.time > nextFireTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePoint.forward * bulletSpeed;
            }
            Destroy(bullet, 5f);
            nextFireTime = Time.time + fireRate;
        }
    }
  }
