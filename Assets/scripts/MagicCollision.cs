using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCollision : MonoBehaviour
{
    public int attackPower; // ���@�̍U����
    public GameObject hitEffect; // �q�b�g�G�t�F�N�g

    void OnCollisionEnter(Collision collision)
    {
        // �G�ɏՓ˂����ꍇ
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // �G�Ƀ_���[�W��^����
           Health enemy = collision.gameObject.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackPower);
            }

            // �q�b�g�G�t�F�N�g���Đ�
            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }
        }

        // ���@��j��
        Destroy(gameObject);
    }
}

