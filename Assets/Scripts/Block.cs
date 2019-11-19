using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip damageSound;
    [SerializeField] int health = 1;
    [SerializeField] Sprite[] damagedSprites;

    Level level;
    int currentSprite = 0;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(damageSound != null) { // TODO Create the damage sound (do I want diff sound for dmg vs. death)?
            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);
        }
        if(--health == 0)
        {
            DestroyBlock();
        } else
        {
            GetComponent<SpriteRenderer>().sprite = damagedSprites[currentSprite];
            currentSprite++;
        }
    }

    private void DestroyBlock()
    {
        level.DestroyBlock();
        if(level.LevelCleared())
        {
            //TODO show win message with button to click, or auto go to next level?
            FindObjectOfType<SceneLoader>().LoadNext();
        }
        Destroy(gameObject);
    }
}
