using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicSwicher : MonoBehaviour
{
    
    //public SkillData[] magicSkills;
    public Text magicNameText;
    public Image magicIconImage;

    private int currentMagicIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMagicUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q))
        {
            SwitchMagic(-1);
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            SwitchMagic(1);
        }
    }

    void SwitchMagic(int direction)
    {
        currentMagicIndex = (currentMagicIndex + direction + DataBaseManager.instance. skillDataSO.skillDataList.Count)% DataBaseManager.instance.skillDataSO.skillDataList.Count;

        UpdateMagicUI();
    }

    void UpdateMagicUI()
    {
        SkillData currentMagic = DataBaseManager.instance.skillDataSO.skillDataList[currentMagicIndex];

        magicNameText.text = currentMagic.skillName;
        if (magicIconImage != null)
        {
            magicIconImage.sprite = currentMagic.icon;
        }
        Debug.Log("Current Magic: " + currentMagic.skillName);
    }

    public GameObject GetSkillPrefab()
    {
        SkillData currentMagic = DataBaseManager.instance.skillDataSO.skillDataList[currentMagicIndex];
        return currentMagic.skillPrefab;
    }

    public float GetMoveSpeed()
    {
        SkillData currentMagic = DataBaseManager.instance.skillDataSO.skillDataList[currentMagicIndex];
        return currentMagic.moveSpeed;
    }

    public int GetAttackPower()
    {
        return DataBaseManager.instance.skillDataSO.skillDataList[currentMagicIndex].attackPower;
    }

    public GameObject GetHitEffect()
    {
        SkillData currentMagic = DataBaseManager.instance.skillDataSO.skillDataList[currentMagicIndex];
        return currentMagic.hitEffect;
    }

    public int GetCost()
    {
        SkillData currentMagic = DataBaseManager.instance.skillDataSO.skillDataList[currentMagicIndex];
        return currentMagic.cost;
    }
}
