using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;

    private Vector2 lookDirection = new Vector2(1, 0);

    private PlayerAnimation playerAnim;

    [SerializeField]
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);

        TryGetComponent(out playerAnim);
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        if(playerAnim)
        {
            SyncMoveAnimation();
        }
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

    private void SyncMoveAnimation()
    {
        if(!Mathf.Approximately(moveH,0.0f)|| !Mathf.Approximately(moveV,0.0f))
        {
            lookDirection.Set(moveV, moveH);
            lookDirection.Normalize();
            playerAnim.ChangeAnimationFromFloat(PlayerAnimationState.Speed,lookDirection.sqrMagnitude);

            Debug.Log("à⁄ìÆÉAÉjÉÅçƒê∂:" + lookDirection.sqrMagnitude);
        }
        else
        {
            playerAnim.ChangeAnimationFromFloat(PlayerAnimationState.Speed, 0);
            Debug.Log("í‚é~");
        }
    }
}
