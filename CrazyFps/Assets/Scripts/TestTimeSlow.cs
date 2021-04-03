using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeSlow : MonoBehaviour
{
    public bool SlowTime = false;
    public float value = 0.2f;
    private void Update()
    {
        if (SlowTime)
        {
            Time.timeScale = value;
        }
    }

}
