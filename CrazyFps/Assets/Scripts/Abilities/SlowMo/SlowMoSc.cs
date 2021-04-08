using TMPro;
using UnityEngine;

public class SlowMoSc : MonoBehaviour
{
    public float slowMoValue = 0.5f;
    
    public bool isSlowOn = false;

    private void Update()
    {
        SlowMoAbility();
    }

    public void SlowMoAbility()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isSlowOn)
            {
                Time.timeScale = slowMoValue;
                Time.fixedDeltaTime = Time.timeScale * .02f;
                isSlowOn = true;
            }
            else
            {
                Time.timeScale = 1f;
                isSlowOn = false;
            }
        }
    }
}
