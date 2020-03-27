using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Loader : MonoBehaviour
{
   

    public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
 
}
