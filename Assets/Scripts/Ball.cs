using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] float launchSpeed = 10f;
    [SerializeField] AudioClip wallHitFX, playerHitFX, blockHitFX;
    

    private bool isSticky = true; // Starting sticky to true, might make powerup to enable sticky mid game
    private Vector2 paddleToBall;
    private AudioSource vfxPlayer;
    void Start()
    {
        isSticky = true;
        paddleToBall = transform.position - paddle.transform.position;
        vfxPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if(isSticky)
        {
            StickBallToPaddle();
            LaunchOnClick();
        }
      

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" && wallHitFX != null)
        {
            vfxPlayer.PlayOneShot(wallHitFX);
           
        }
        else if( collision.gameObject.tag == "Player" && playerHitFX != null )
        {
            vfxPlayer.PlayOneShot(playerHitFX);
        }
        else if ( collision.gameObject.tag == "Block" && blockHitFX != null )
        {
            Block b = collision.gameObject.GetComponent<Block>();
            if(!b.isBreakable())
            {
                vfxPlayer.pitch = 0.8f; // Serialize?
            }
            vfxPlayer.PlayOneShot(blockHitFX);
            vfxPlayer.pitch = 1.0f; // Reset
        }
    }

    public void StickBallToPaddle()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y) + paddleToBall;
    }

    private void LaunchOnClick()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            isSticky = false;
            float mouseDir = Input.GetAxis("Mouse X");
            if(mouseDir != 0)
            {
                mouseDir = mouseDir / Mathf.Abs(mouseDir); // should become 1 or -1 depending on direction
            }
            var vector = new Vector2(5f * mouseDir, launchSpeed);
            GetComponent<Rigidbody2D>().velocity = vector;
        }
    }
}
