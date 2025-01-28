using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicSwicher : MonoBehaviour
{
    [SerializeField]
    private SkillDataSO skillDataSO;
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
        currentMagicIndex = (currentMagicIndex + direction + skillDataSO.skillDataList.Count)% skillDataSO.skillDataList.Count;

        UpdateMagicUI();
    }

    void UpdateMagicUI()
    {
        SkillData currentMagic = skillDataSO.skillDataList[currentMagicIndex];

        magicNameText.text = currentMagic.skillName;
        if (magicIconImage != null)
        {
            magicIconImage.sprite = currentMagic.icon;
        }
        Debug.Log("Current Magic: " + currentMagic.skillName);
    }

    public GameObject GetSkillPrefab()
    {
        SkillData currentMagic = skillDataSO.skillDataList[currentMagicIndex];
        return currentMagic.skillPrefab;
    }

    public float GetMoveSpeed()
    {
        SkillData currentMagic = skillDataSO.skillDataList[currentMagicIndex];
        return currentMagic.moveSpeed;
    }

    public int GetAttackPower()
    {
        return skillDataSO.skillDataList[currentMagicIndex].attackPower;
    }
}
