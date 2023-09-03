using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private ParticleSystem _deathParticles;

    [SerializeField] private float _attackSpeed = 1000f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 1f);
        
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.forward * Time.fixedDeltaTime * _attackSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            _deathParticles.gameObject.transform.position = collision.gameObject.transform.position;
            _deathParticles.Play();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
