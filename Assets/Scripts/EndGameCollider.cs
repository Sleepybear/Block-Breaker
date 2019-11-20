using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameSession loader = FindObjectOfType<GameSession>();
        loader.EndGame();
    }
}
