using UnityEngine.SceneManagement;
using UnityEngine;

public class resetLevelSc : MonoBehaviour
{
    void Start()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level02");
        }
    }
}
