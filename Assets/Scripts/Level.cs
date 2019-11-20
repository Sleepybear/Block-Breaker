using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int totalBlocks = 0;
    
    public void AddBlock()
    {
        totalBlocks++;
    }

    public void DestroyBlock(int points)
    {
        FindObjectOfType<GameSession>().AddToScore(points);
        totalBlocks--;
    }

    public bool LevelCleared()
    {
        return (totalBlocks <= 0);
    }
}
