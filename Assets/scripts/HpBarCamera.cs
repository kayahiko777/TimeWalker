using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        LookHpBarToCamera();
    }

    /// <summary>
    /// HpBar����ɃJ�����̕����Ɍ�����
    /// </summary>
    private void LookHpBarToCamera()
    {
        transform.localRotation = Camera.main.transform.rotation;
    }
}
