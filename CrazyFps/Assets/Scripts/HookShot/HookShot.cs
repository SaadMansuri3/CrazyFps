using UnityEngine;

public class HookShot : MonoBehaviour
{
    #region Varibales
    [HeaderAttribute("Required Entities")]
    //public Transform debugPointTransform;
    public Camera playerCamera;
    public Rigidbody rb;
    public CharacterController cc;
    public Transform hookShotTransform;
    public ParticleSystem SpeedParticles;
    //public HookShotCamSC hookShotCam;

    [HeaderAttribute("Attributes")]
    public float hookShotThrowSpeed = 100f;
    //private float normalFov = 60f;
    //private float hookShotFov = 100f;


    private Vector3 hookShotPosition;
    private float hookShotSize = 0f;

    private State state;

    #endregion

    #region State Declaration
    private enum State
    {
        Normal,
        HookShotFlyingPlayer,
        HookShotThrown

    }

    #endregion

    private void Awake()
    {
        SpeedParticles.Stop();
        cc.enabled = false;
        state = State.Normal;
        hookShotTransform.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        switch (state)
        {
            default:
            case State.Normal:
                rb.isKinematic = false;
                cc.enabled = false;
                HookShotStart();
                break;

            case State.HookShotFlyingPlayer:
                rb.isKinematic = true;
                cc.enabled = true;
                HookShotPlayerMovement();
                break;

            case State.HookShotThrown:
                HookShotThrow();
                break;
        }
    }

    void HookShotStart()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit);
            if (hit.transform == null)
            {
                return;
            }
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                //debugPointTransform.position = hit.point;
                hookShotPosition = hit.point;

                hookShotSize = 0f;
                hookShotTransform.gameObject.SetActive(true);
                hookShotTransform.localScale = Vector3.zero;
                state = State.HookShotThrown;
            }
        }
    }

    private void HookShotThrow()
    {
        hookShotTransform.LookAt(hookShotPosition);

        hookShotSize += hookShotThrowSpeed * Time.deltaTime;
        hookShotTransform.localScale = new Vector3(1, 1, hookShotSize);

        if (hookShotSize >= Vector3.Distance(transform.position, hookShotPosition))
        {
            state = State.HookShotFlyingPlayer;
            SpeedParticles.Play();
            //hookShotCam.SetCamFov(hookShotFov);
        }

    }

    void HookShotPlayerMovement()
    {
        hookShotTransform.LookAt(hookShotPosition);


        Vector3 hookShotDir = (hookShotPosition - transform.position).normalized;

        float minHookShotSpeed = 10f;
        float maxHookShotSpeed = 40f;

        float originalHookShotSize = hookShotSize;
        hookShotSize -= hookShotThrowSpeed * Time.deltaTime;
        hookShotTransform.localScale = new Vector3(1, 1, Mathf.Clamp(hookShotSize, 0, originalHookShotSize));

        float hookShotSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookShotPosition), minHookShotSpeed, maxHookShotSpeed);
        float hookShotSpeedMultiplier = 2f;

        cc.Move(hookShotDir * hookShotSpeed * hookShotSpeedMultiplier * Time.deltaTime);

        if (Vector3.Distance(transform.position, hookShotPosition) <= 1.5f)
        {
            StopHookShot();
        }

        if (InputHookShotJumpStop())
        {
            StopHookShot();
        }
    }

    private bool InputHookShotJumpStop()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private void StopHookShot()
    {
        state = State.Normal;
        hookShotTransform.gameObject.SetActive(false);
        SpeedParticles.Stop();
        //hookShotCam.SetCamFov(normalFov);
    }

}
