using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private float manaInterval;
    [SerializeField]
    private int manaRecoveryPoint;
    [SerializeField]
    private int currentMana;
    [SerializeField]
    private int maxMana;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�@�Q�[�����̎��Ԃ��v��
        timer += Time.deltaTime;

        //�@�v�����Ă��鎞�Ԃ��ڕW�l�𒴂��������肷��
        if (timer >= manaInterval)
        {
            //�@�ڕW�l�𒴂��Ă���ꍇ�v�����Ԃ����Z�b�g����
            timer = 0;
            //�@�}�i���w��l���񕜂���
            Debug.Log("�}�i��");
            GainMana(manaRecoveryPoint);
        }
    }

    /// <summary>
    /// �}�i��
    /// </summary>
    /// <param name="manaPoint"></param>
    public void GainMana(int manaPoint)
    {
        // �}�i�|�C���g�̕�����currentMana�����Z
        currentMana += manaPoint;

        // currentMana���ő�l�𒴂��Ȃ��悤�ɐ�������
        currentMana = Mathf.Min(currentMana, maxMana);
    }

    /// <summary>
    /// �}�i����
    /// </summary>
    /// <param name="manaCost"></param>
    public void ConsumeMana(int manaCost)
    {
        //�@�}�i�|�C���g�̕�����currentMana�����Z
        currentMana -= manaCost;
    }

    /// <summary>
    /// ���@���g���邩�m�F
    /// true�Ȃ疂�@���g����
    /// </summary>
    /// <param name="manaCost"></param>
    /// <returns></returns>
    public bool ChackManaCost(int manaCost) 
    {
        // currentMana��manaCost��荂���ꍇ���@���g����
        if (currentMana >= manaCost)
        {
            return true;
        }
        
        return false;

    }
}
