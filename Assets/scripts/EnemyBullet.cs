using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int attackPower; // ���@�̍U����
    public GameObject hitEffect; // �q�b�g�G�t�F�N�g

    void OnCollisionEnter(Collision collision)
    {
        // �G�ɏՓ˂����ꍇ
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player��Barrier�̃X�N���v�g���A�^�b�`����Ă���ꍇ
            if (collision.gameObject.TryGetComponent(out Barrier barrier)) 
            {
                // ���G��ԂȂ̂ŏ������I������
                return;
            }

            // �G�Ƀ_���[�W��^����
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackPower);
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
