using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    void Awake()
    {
        Destroy(gameObject, 10f);
    }


}
