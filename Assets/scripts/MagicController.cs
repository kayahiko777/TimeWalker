using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    [SerializeField]
    private MagicSwicher magicSwicher;
   // public GameObject magicPrefab;
    public Transform magicSpawnPoint;
   // public float magicSpeed = 10f;

   // public GameObject hitEffect;
    //[SerializeField]
    //private int attackPower;


  
   
   
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
        int cost = magicSwicher.GetCost();
        bool canCastMagic = ManaManager.instance.ChackManaCost(cost);
        if (canCastMagic == false)
        {
            return;
        }
        if ( magicSpawnPoint != null)
        {
            //GameObject magic = Instantiate(magicPrefab, magicSpawnPoint.position, magicSpawnPoint.rotation);
            GameObject skillPrefab = magicSwicher.GetSkillPrefab();
            if (skillPrefab == null) { return;  }
            GameObject magic = Instantiate(skillPrefab, magicSpawnPoint.position, magicSpawnPoint.rotation);
            Rigidbody rb = magic.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float magicSpeed = magicSwicher.GetMoveSpeed();
                rb.velocity = magicSpawnPoint.forward * magicSpeed;
                rb.isKinematic = false;
            }
           // Physics.IgnoreCollision(magic.GetComponentInChildren<Collider>(), GetComponent<Collider>());
            Destroy(magic, 5f);

            MagicCollision magicCollision = magic.GetComponent<MagicCollision>();
            int attackPower = magicSwicher.GetAttackPower();
            magicCollision.SetUpAttackPower(attackPower);

            GameObject hitEffect = magicSwicher.GetHitEffect();
            if (hitEffect != null)
            {
                magicCollision.SetUpHitEffect(hitEffect);
            }
           // magicCollision.attackPower = attackPower;
           // magicCollision.hitEffect = hitEffect;
           ManaManager.instance.ConsumeMana(cost);
        }
    }
    
}
