using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuSc : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Level01");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1)
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
