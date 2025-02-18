using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField]
    private Button btnStageSelect;
    [SerializeField]
    private int stageNo;
    // Start is called before the first frame update
    void Start()
    {
        btnStageSelect.onClick.AddListener(ChangeStage);
    }

    private void ChangeStage()
    {
        UserData.instance.selectStageNo= stageNo;

        switch (stageNo)
        {
            case 1:
                SceneManager.LoadScene("SampleScene");
                break;

            case 2:
                SceneManager.LoadScene("MainScene");
                break;

            case 3:
                Debug.Log("ステージNo," +  stageNo);
               // SceneManager.LoadScene("");
                break;
        }

    }
}
