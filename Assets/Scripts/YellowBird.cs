using UnityEngine;
using UnityEngine.InputSystem;

public class YellowBird : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;

    [Header("Dash Settings")]
    [SerializeField] private float _dashMultiplier = 2.0f; // Hệ số tăng tốc
    [SerializeField] private float _minDashSpeed = 1.0f;   // Tốc độ tối thiểu để dash

    private bool _hasBeenLaunched = false;
    private bool _shouldFaceVelDirection = false;
    private bool _hasDashed = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        _rb.isKinematic = true;
        _circleCollider.enabled = false;
    }

    private void FixedUpdate()
    {
        if (_hasBeenLaunched && _shouldFaceVelDirection)
        {
            if (_rb.linearVelocity.magnitude > 0.1f)
                transform.right = _rb.linearVelocity;
        }
    }

    private void Update()
    {
        if (_hasBeenLaunched && !_hasDashed)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Dash();
            }
        }
    }

    public void LaunchBird(Vector2 direction, float force)
    {
        _rb.isKinematic = false;
        _circleCollider.enabled = true;

        _rb.AddForce(direction * force, ForceMode2D.Impulse);

        _hasBeenLaunched = true;
        _shouldFaceVelDirection = true;
    }


    private void Dash()
    {
        Vector2 currentVelocity = _rb.linearVelocity;

        if (currentVelocity.magnitude > _minDashSpeed)
        {
            Vector2 dashVelocity = currentVelocity.normalized * currentVelocity.magnitude * _dashMultiplier;
            _rb.linearVelocity = dashVelocity;

            _hasDashed = true; // Chỉ dash 1 lần
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _shouldFaceVelDirection = false;
    }
}
