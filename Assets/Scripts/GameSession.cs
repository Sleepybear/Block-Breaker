using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int endGameSceneIndex;
    [SerializeField] int firstLevelIndex;

    private int totalLevels, currentLevel;

    private void Awake()
    {
        int managers = FindObjectsOfType<GameSession>().Length;
        if( managers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevelIndex);
        totalLevels = SceneManager.sceneCountInBuildSettings - 2;
        currentLevel = 1;
    }
    public void LoadNext()
    {
        if(currentLevel == totalLevels)
        {
            SceneManager.LoadScene(firstLevelIndex);
        } else
        {
            currentLevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(endGameSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
