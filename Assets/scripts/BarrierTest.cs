using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTest : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetBarrier();
        }
    }

    private void GetBarrier()
    {
        if (player.TryGetComponent(out Barrier barrier))
        {
            return;
        }

        player.AddComponent<Barrier>();
    }
}
