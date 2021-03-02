using TMPro;
using UnityEngine;

public class SlowMoSc : MonoBehaviour
{
    public float slowMoDuration = 5f;
    public float slowMoValue = 0.2f;
    public TextMeshProUGUI abilityDisplay;
    
    
    private float currentSlowMo;
    private bool isSlowOn = false;

    private void Update()
    {
        if (abilityDisplay != null)
        {
            abilityDisplay.SetText(currentSlowMo + "/" + slowMoDuration);
        }
        SlowMoAbility();
    }

    public void SlowMoAbility()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isSlowOn && currentSlowMo > 0)
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
