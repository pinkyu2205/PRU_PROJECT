using UnityEngine;

<<<<<<< HEAD
public class Angiebird : MonoBehaviour
{
=======
public class AngieBird : MonoBehaviour
{
    [SerializeField] private AudioClip _hitClip;

>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f
    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;

    private bool _hasBeenLaunched;
    private bool _shouldFaceVelDirection;

<<<<<<< HEAD
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        _rb.isKinematic = true;
=======
    private AudioSource _audioSource;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();   
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _rb.bodyType = RigidbodyType2D.Kinematic;
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f
        _circleCollider.enabled = false;
    }

    private void FixedUpdate()
    {
<<<<<<< HEAD
        if (_hasBeenLaunched && _shouldFaceVelDirection)
        {
        transform.right = _rb.linearVelocity;

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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        _shouldFaceVelDirection = false;
    }

=======
        if(_hasBeenLaunched && _shouldFaceVelDirection)
        {
            transform.right = _rb.linearVelocity;

        }
    }

    public void LaunchBird (Vector2 direction, float force)
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _circleCollider.enabled = true;

        //apply the force
        _rb.AddForce(direction * force, ForceMode2D.Impulse);

        _hasBeenLaunched = true;
        _shouldFaceVelDirection = true; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _shouldFaceVelDirection = false;
        SoundManager.instance.PlayClip(_hitClip, _audioSource);
        Destroy(this);
    }
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f
}
