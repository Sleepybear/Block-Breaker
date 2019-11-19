using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip damageSound;
    [SerializeField] int health = 1;
    [SerializeField] Sprite[] damagedSprites;

    int currentSprite = 0;

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
        // TODO see if last object alive
        Destroy(gameObject);
    }
}
