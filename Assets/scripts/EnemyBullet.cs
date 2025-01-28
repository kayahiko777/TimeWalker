using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int attackPower; // 魔法の攻撃力
    public GameObject hitEffect; // ヒットエフェクト

    void OnCollisionEnter(Collision collision)
    {
        // 敵に衝突した場合
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            // PlayerにBarrierのスクリプトがアタッチされている場合
            if (collision.gameObject.TryGetComponent(out Barrier barrier)) 
            {
                // 無敵状態なので処理を終了する
                return;
            }

            // 敵にダメージを与える
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackPower);
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
}
