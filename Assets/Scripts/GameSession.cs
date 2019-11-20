using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    [SerializeField] int endGameSceneIndex;
    [SerializeField] int firstLevelIndex;
    [SerializeField] TextMeshProUGUI scoreDisplay;

    private int totalLevels, currentLevel, currentScore;

    private void Awake()
    {
        int managers = FindObjectsOfType<GameSession>().Length;
        if( managers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            scoreDisplay.enabled = false;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        totalLevels = SceneManager.sceneCountInBuildSettings - 2;
    }

    private void Update()
    {
        if(Debug.isDebugBuild)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                LoadNext();
            }
        }
    }
    public void StartGame()
    {
        scoreDisplay.enabled = true;
        this.currentLevel = 1;
        this.currentScore = 0;
        UpdateScoreText();
        SceneManager.LoadScene(firstLevelIndex);
    }

    private void UpdateScoreText()
    {
        scoreDisplay.text = currentScore.ToString();
    }

    public void AddToScore(int points)
    {
        currentScore += points;
        UpdateScoreText();
    }

    public void LoadNext()
    {
        if(currentLevel == totalLevels)
        {
            SceneManager.LoadScene(firstLevelIndex);
            currentLevel = 1;
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
