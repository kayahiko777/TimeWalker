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
    /// HpBar‚ğí‚ÉƒJƒƒ‰‚Ì•ûŒü‚ÉŒü‚¯‚é
    /// </summary>
    private void LookHpBarToCamera()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
