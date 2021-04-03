using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSc : MonoBehaviour
{
    public float destroyAfterSeconds = 5f;
    //public ParticleSystem hitParticle;
    private void Awake()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //hitParticle.Play();
        Destroy(gameObject);
    }
}
