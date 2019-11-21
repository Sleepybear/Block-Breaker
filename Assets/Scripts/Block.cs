using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip deathSound;
    [SerializeField] int health = 1;
    [SerializeField] Sprite[] damagedSprites;
    [SerializeField] ParticleSystem destroyVFX;
    [SerializeField] int points = 32;
    [SerializeField] bool breakable = true;

    Level level;
    int currentSprite = 0;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (isBreakable())
        {
            level.AddBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if( !isBreakable() )
        {
            // Just collide, do nothing else
            return;
        }
        if(--health == 0)
        {
            DestroyBlock(this.points);
        } else
        {
            GetComponent<SpriteRenderer>().sprite = damagedSprites[currentSprite];
            currentSprite++;
        }
    }

    public bool isBreakable()
    {
        return breakable;
    }

    private void DestroyBlock(int points)
    {
        level.DestroyBlock(points);
        ParticleSystem particles = GameObject.Instantiate(destroyVFX, transform.position, transform.rotation);
        Destroy(particles.gameObject, 2f);
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        }
        if(level.LevelCleared()) // Maybe move this to Level.cs? Makes more sense for the level to be checking if it's cleared.
        {
            //TODO show win message with button to click, or auto go to next level?
            FindObjectOfType<GameSession>().LoadNext();
        }
        Destroy(gameObject);
    }
}
