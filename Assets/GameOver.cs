using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void RetrunToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
