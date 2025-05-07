using UnityEngine;
using UnityEngine.InputSystem;

public class FarmPlayerController : BaseController
{
    [SerializeField] private float jumpForce = 20f;
    private bool isJump = false;
    private bool isGround = false;

    public void Init()
    {
        statController.Speed = 5f;
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
        lookDirection = movementDirection;
    }

    void OnJump(InputValue inputValue)
    {
        isJump = inputValue.isPressed;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (isJump && isGround)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    protected override void Movement(Vector2 direction)
    {
        direction *= statController.Speed;

        _rb.velocity = new Vector2(direction.x, _rb.velocity.y);
        animationController.Move(direction);
    }

    protected override void Rotate(Vector2 direction)
    {
        if (direction.x < 0)
            spriteRenderer.flipX = true;

        else if (direction.x > 0)
            spriteRenderer.flipX = false;
    }
}

