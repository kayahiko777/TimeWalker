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
        //　ゲーム内の時間を計測
        timer += Time.deltaTime;

        //　計測している時間が目標値を超えたか判定する
        if (timer >= manaInterval)
        {
            //　目標値を超えている場合計測時間をリセットする
            timer = 0;
            //　マナを指定値分回復する
            Debug.Log("マナ回復");
            GainMana(manaRecoveryPoint);
        }
    }

    /// <summary>
    /// マナ回復
    /// </summary>
    /// <param name="manaPoint"></param>
    public void GainMana(int manaPoint)
    {
        // マナポイントの分だけcurrentManaを加算
        currentMana += manaPoint;

        // currentManaが最大値を超えないように制限する
        currentMana = Mathf.Min(currentMana, maxMana);
    }

    /// <summary>
    /// マナ消費
    /// </summary>
    /// <param name="manaCost"></param>
    public void ConsumeMana(int manaCost)
    {
        //　マナポイントの分だけcurrentManaを減算
        currentMana -= manaCost;
    }

    /// <summary>
    /// 魔法が使えるか確認
    /// trueなら魔法が使える
    /// </summary>
    /// <param name="manaCost"></param>
    /// <returns></returns>
    public bool ChackManaCost(int manaCost) 
    {
        // currentManaがmanaCostより高い場合魔法が使える
        if (currentMana >= manaCost)
        {
            return true;
        }
        
        return false;

    }
}
