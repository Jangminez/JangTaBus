using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;

    [SerializeField] ParticleSystem particle;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] public bool isDead = false;
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip deathClip;
    bool isUp = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();

        if (_anim == null)
            Debug.LogError("Null Animator");
        if (_rb == null)
            Debug.LogError("Null Rigidbody");
    }

    void Update()
    {
        if(isDead) return;

        if (Input.GetMouseButtonDown(0))
        {
            isUp = true;
        }
    }
    void FixedUpdate()
    {
        if(isDead) return;

        if (isUp)
        {
            SoundManager.PlaySFX(jumpClip);

            _rb.velocity = Vector2.zero;
            _rb.velocity += Vector2.up * jumpForce;
            isUp = false;
        }

        float angle = Mathf.Clamp(_rb.velocity.y * 3f, -90f, 90f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead) return;

        SoundManager.PlaySFX(deathClip);
        
        isDead = true;

        particle.Stop();
        _anim.SetTrigger("IsDie");

        GameManager.Instance.MiniGameOver();
    }
}
