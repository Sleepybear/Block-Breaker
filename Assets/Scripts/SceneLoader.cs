using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int EndGameSceneIndex;
    [SerializeField] int FirstLevelIndex;
    private int currentLevel;
    private int totalLevels;

    private void Awake()
    {
        int loaders = FindObjectsOfType<SceneLoader>().Length;
        if(loaders >1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        totalLevels = SceneManager.sceneCount - 2; // Minus two because we don't want to count splash or end game screens
    }

    public void StartGame()
    {
        SceneManager.LoadScene(FirstLevelIndex);
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(++currentLevel % totalLevels);
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
