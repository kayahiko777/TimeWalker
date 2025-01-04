using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    public GameObject magicPrefab;
    public Transform magicSpawnPoint;
    public float magicSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CastMagic();
        }
    }

    void CastMagic()
    {
        if (magicPrefab != null && magicSpawnPoint != null)
        {
            GameObject magic = Instantiate(magicPrefab, magicSpawnPoint.position, magicSpawnPoint.rotation);

            Rigidbody rb = magic.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = magicSpawnPoint.forward * magicSpeed;
                rb.isKinematic = false;
            }
            Physics.IgnoreCollision(magic.GetComponent<Collider>(), GetComponent<Collider>());
            Destroy(magic, 5f);
        }
    }
}
