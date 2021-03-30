using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{

    public bool activated = true;
    public Rigidbody rb;
    public float rotationSpeed;

    void Update()
    {
        if (activated)
        {
            transform.Rotate(rotationSpeed, 0, 0);
            //rb.AddTorque(transform.TransformDirection(Vector3.right) * 100, ForceMode.Impulse);
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        activated = false;
        rb.isKinematic = true;
    }
}
