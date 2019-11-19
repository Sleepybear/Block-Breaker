using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int EndGameSceneIndex;
    [SerializeField] int NextLevelIndex;

    public void LoadNext()
    {
         SceneManager.LoadScene(NextLevelIndex);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(EndGameSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
