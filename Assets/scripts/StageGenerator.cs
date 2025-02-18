using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject stagePrefab = DataBaseManager.instance.GetStagePrefab();
        GameObject stage = Instantiate(stagePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
