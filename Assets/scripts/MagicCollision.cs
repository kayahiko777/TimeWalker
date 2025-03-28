using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCollision : MonoBehaviour
{
    public int attackPower; // 魔法の攻撃力
    public GameObject hitEffect; // ヒットエフェクト

    void OnCollisionEnter(Collision collision)
    {
        // 敵に衝突した場合
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 敵にダメージを与える
           Health enemy = collision.gameObject.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackPower);
            }

            // ヒットエフェクトを再生
            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }
        }

        // 魔法を破壊
        Destroy(gameObject);
    }

    /// <summary>
    /// SOから攻撃力をもらう
    /// </summary>
    /// <param name="newAttackPower">新しい攻撃力</param>
    public void SetUpAttackPower(int newAttackPower)
    {
        this.attackPower = newAttackPower;
    }

    public void SetUpHitEffect(GameObject newhitEffect)
    {
        hitEffect = newhitEffect;
    }
}

