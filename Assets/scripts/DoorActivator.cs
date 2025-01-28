using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorActivator : MonoBehaviour
{
    [SerializeField]
    private float targetPosY = -1.5f;
    [SerializeField]
    private float duration = 3.0f;
    public void OpenDoor()
    {
        //gameObject.SetActive(false);
        transform.DOMoveY(targetPosY, duration).SetEase(Ease.Linear);
    }
}
