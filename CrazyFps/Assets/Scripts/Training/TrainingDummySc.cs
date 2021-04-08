using System.Collections;
using UnityEngine;

public class TrainingDummySc : MonoBehaviour
{
    private float health = 50f;

    public ParticleSystem hitParticles;

    public ParticleSystem deathParticle;

    public ParticleSystem respawnParticle;
    public GameObject gfx;

    public GameObject Teleporter;

    private float waitSecs = 7f;


    private void Awake()
    {
        Teleporter.SetActive(false);
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            deathParticle.Play();
            halt();
            if (!Teleporter.activeSelf)
            {
                Teleporter.SetActive(true);
            }
        }
    }

    void halt()
    {
        StartCoroutine(LateCall());
        gfx.SetActive(false);
    }

    
    private IEnumerator LateCall()
    {
        yield return new WaitForSeconds(waitSecs);
        respawnParticle.Play();
        gfx.SetActive(true);

        health = 50f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitParticles.Play();
        if(collision.gameObject.layer == LayerMask.NameToLayer("9bullet"))
        {
            TakeDamage(7);
        }
    }
}
