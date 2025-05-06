using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FarmPlayerController : BaseController
{
    [SerializeField] private float jumpForce = 5f;
    public void Init()
    {

    }

    protected override void Start()
    {
        base.Start();

        Init();
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
        lookDirection = _rb.velocity;
    }

    void OnJump(InputValue inputValue)
    {
        _rb.velocity += Vector2.up * jumpForce;
    }
}
