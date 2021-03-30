using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeControllerTestSc : MonoBehaviour
{
    public Rigidbody axeRb;
    public Transform axe;
    public Camera playerCam;
    public float throwPower = 10f;
    public Transform target, curvePoint;
    public Transform parentTransform;
    public AxeScript axeSc;
    public TrailRenderer trailrender;
    public ParticleSystem catchParticle;

    private Vector3 old_pos;
    private bool isReturning = false;
    private float time = 0.0f;
    private bool canReturn = false;
    private bool canThrow = true;
    private Vector3 origLocPos;
    private Vector3 origLocRot;

    private void Start()
    {
        catchParticle.Stop();
        trailrender.emitting = false;
        axeSc.activated = false;
        origLocPos = axe.position;
        origLocRot = axe.localEulerAngles;
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1") && canThrow)
        {
            AxeThrow();
            canReturn = true;
            canThrow = false;
        }

        if (Input.GetButtonUp("Fire2") && canReturn)
        {
            AxeReturn();
            axeSc.activated = false;
            canReturn = false;
        }

        if (isReturning)
        {
            if (time < 1f)
            {
                axeRb.position = getBQCPoint(time, old_pos, curvePoint.position, target.position);
                axeRb.rotation = Quaternion.Slerp(axeRb.transform.rotation, target.rotation, 50 * Time.deltaTime);
                time += Time.deltaTime;
            }
            else
            {
                AxeReset();
            }
        }


    }

    public void AxeThrow()
    {
        axeSc.activated = true;
        isReturning = false;
        
        axeRb.isKinematic = false;
        axeRb.transform.parent = null;
        axeRb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        
        axeRb.AddForce(playerCam.transform.forward * throwPower, ForceMode.Impulse);
        trailrender.emitting = true;
    }

    void AxeReturn()
    {
        time = 0f;
        old_pos = axeRb.position;
        isReturning = true;
        axeRb.velocity = Vector3.zero;
        axeRb.isKinematic = true;
        canReturn = false;
        trailrender.emitting = true;
    }

    void AxeReset()
    {
        isReturning = false;
        axeSc.activated = false;
        axeRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        axeRb.transform.parent = parentTransform;
        axe.position = target.position;
        axe.localEulerAngles= origLocRot;
        axeSc.activated = false;
        axeRb.Sleep();
        canReturn = false;
        canThrow = true;
        catchParticle.Play();
        trailrender.emitting = false;
    }

    Vector3 getBQCPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }
}
