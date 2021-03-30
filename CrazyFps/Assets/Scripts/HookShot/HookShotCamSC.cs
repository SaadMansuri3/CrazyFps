using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShotCamSC : MonoBehaviour
{
    public Camera playerCamera;
    
    private float targetFov;
    private float fov;

    private void Awake()
    {
        targetFov = playerCamera.fieldOfView;
        fov = targetFov;
    }

    void Update()
    {
        float fovSpeed = 4f;
        fov = Mathf.Lerp(fov, targetFov, Time.deltaTime * fovSpeed);
        playerCamera.fieldOfView = fov;
    }

    public void SetCamFov(float targetFov)
    {
        this.targetFov = targetFov;
    }
}
