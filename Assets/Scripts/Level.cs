using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Tooltip("Modifier to speed of time. 1 = normal, >1 is sped up, <1 is slowed down")]
    [SerializeField][Range(0.1f,3f)] float timeScale = 1f;
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
