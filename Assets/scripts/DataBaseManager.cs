using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;

  
    public SkillDataSO skillDataSO;
    public StageDataSO stageDataSO;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public GameObject GetStagePrefab()
    {
        StageData stageData = stageDataSO.stageDataList
            .FirstOrDefault(data => data.stageNo == UserData.instance.selectStageNo);
        return stageData.stagePrefab;
    }
}
