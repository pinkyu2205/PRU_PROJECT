using UnityEngine;
using System.Collections;

public class Baddie : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3f;
    [SerializeField] private float _damageThreshold = 0.2f;
    [SerializeField] private GameObject _baddieDeathParticle;
    [SerializeField] private AudioClip _deathClip;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        // Đăng ký chính mình vào GameManager
        if (GameManager.instance != null)
        {
            GameManager.instance.RegisterBaddie(this);

        }
    }

    public void DamageBaddie(float damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.instance.RemoveBaddies(this);

        Instantiate(_baddieDeathParticle, transform.position, Quaternion.identity);

        AudioSource.PlayClipAtPoint(_deathClip, transform.position);
        Destroy(gameObject); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactVelocity = collision.relativeVelocity.magnitude;

        if (impactVelocity > _damageThreshold)
        {
            DamageBaddie(impactVelocity);
        }
    }
}
