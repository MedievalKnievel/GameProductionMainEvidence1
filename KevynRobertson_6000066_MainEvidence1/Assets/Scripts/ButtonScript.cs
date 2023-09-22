using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ToControls()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        
        Application.Quit();
        print("Quit");
    }
}
