using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSc : MonoBehaviour
{
    public float destroyAfterSeconds = 5f;
    private void Awake()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
}
