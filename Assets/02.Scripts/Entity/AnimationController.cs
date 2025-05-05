using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    protected Animator _anim;

    void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        _anim.SetBool(IsMoving, obj.magnitude > 0.5f);
    }
}
