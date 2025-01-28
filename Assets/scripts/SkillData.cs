using UnityEngine;

[System.Serializable]
public class SkillData 
{
    public Sprite icon;
    public int skillId;
    public string skillName;
    public int attackPower;
    public int shieldPower;
    public float moveSpeed;
    public float coolTime;
    public int cost;
    public float amount1;
    public float amount2;
    public GameObject skillPrefab;
}
