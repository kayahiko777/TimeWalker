using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerAnimationState
{
    Attack,
    Down,
    Damage,
    Jump,
    Speed,
    Idle,
    Clear,
}
public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent(out anim))
        {
            Debug.Log("Animator ÇéÊìæèoóàÇ‹ÇπÇÒ");
        }
    }

    public void ChangeAnimationFromFloat(PlayerAnimationState nextAnimState, float amount)
    {
        anim.SetFloat(nextAnimState.ToString(), amount);
    }

    public void ChangeAnimationBool(PlayerAnimationState nextAnimState,bool isChange)
    {
        anim.SetBool(nextAnimState.ToString(), isChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
