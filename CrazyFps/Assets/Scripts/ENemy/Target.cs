using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;

    public GameObject gfx;

    public ParticleSystem hitParticle;

    public ParticleSystem deathParticle;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            deathParticle.Play();
            gfx.SetActive(false);
            Die();
        }
    }

    void Die()
    {   
        Destroy(gameObject,0.5f);   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("9bullet"))
        {
            hitParticle.Play();
            TakeDamage(7);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Axe"))
        {
            hitParticle.Play();
            TakeDamage(40);
        }
    }
}
