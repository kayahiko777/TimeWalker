using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    private float barrierDuration = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BarrierTime());
    }

    // Update is called once per frame
    IEnumerator BarrierTime()
    {
        yield return new WaitForSeconds(barrierDuration);
        Destroy(this);
    }
}
