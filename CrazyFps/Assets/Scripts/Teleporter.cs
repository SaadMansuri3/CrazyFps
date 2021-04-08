using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public string levelName;
    private bool TeleporterBool = false;

    private void Update()
    {
        if (TeleporterBool)
        {
            TeleportToLevel(levelName);
        }
    }
    private void TeleportToLevel(string level)
    {
        SceneManager.LoadScene(level);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            TeleporterBool = true;
        }
    }

}
