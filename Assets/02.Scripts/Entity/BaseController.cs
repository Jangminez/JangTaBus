using UnityEngine;
using UnityEngine.PlayerLoop;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get => movementDirection; }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get => lookDirection; }

    protected AnimationController animationController;
    protected StatController statController;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        statController = GetComponent<StatController>();
        animationController = GetComponent<AnimationController>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    void Movement(Vector2 direction)
    {
        direction *= statController.Speed;

        _rb.velocity = direction;
        animationController.Move(direction);
    }

    void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90;

        spriteRenderer.flipX = isLeft;
    }
}
