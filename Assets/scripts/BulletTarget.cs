using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    [SerializeField]
    private DoorActivator doorActivator;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Magic"))
        {
            doorActivator. OpenDoor();
            gameObject.SetActive(false);
        }
    }
}
