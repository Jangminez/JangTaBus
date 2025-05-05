using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : BaseController
{
    private Camera _cam;

    public void Init()
    {
        _cam = Camera.main;
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
    }

    void OnLook(InputValue inputValue)
    {
        Vector2 mousePosition = inputValue.Get<Vector2>();
        Vector2 worldPos = _cam.ScreenToWorldPoint(mousePosition);

        lookDirection = worldPos - (Vector2)transform.position;

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }

        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
}
