using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaHeaiArea : MonoBehaviour
{
    [SerializeField]
    private float healRate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ManaManager.instance.ActivateManaArea(healRate);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ManaManager.instance.InActivateManaArea();
        }
    }
}
