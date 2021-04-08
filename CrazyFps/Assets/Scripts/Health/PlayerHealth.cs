using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100;
    public GameObject GameOverUi;
    public GameObject AmmoUi;
    public TextMeshProUGUI healthDisplay;

    private void Start()
    {
        GameOverUi.SetActive(false);
        AmmoUi.SetActive(true);
    }
    void Update()
    {
        healthDisplay.SetText(playerHealth + "/" + "100");

        if(playerHealth <= 0)
        {
            Time.timeScale = 0f;
            GameOverUi.SetActive(true);
            AmmoUi.SetActive(true);

        }    
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
    }
    public void Heal(float amount)
    {
        if (playerHealth + amount < 100)
        {
            playerHealth += amount;
        }
        else
        {
            playerHealth = 100;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("HealthPack"))
        {
            Destroy(other.gameObject);
            Debug.Log("Before Heal" + playerHealth);
            Heal(30);
            Debug.Log("Healed health" + playerHealth);
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Virus"))
        {
            TakeDamage(20);
            Debug.Log(playerHealth);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("TurretBullet"))
        {
            TakeDamage(10);
            Debug.Log(playerHealth);
        }
    }
}
