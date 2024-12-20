using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward,new Vector3(1,0,1)).normalized;

        Vector3 moveForward = cameraForward * moveV + Camera.main.transform.right * moveH;

        rb.velocity = moveForward * moveSpeed + new Vector3(0,rb.velocity.y,0);

        if(moveForward != Vector3.zero )
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}
