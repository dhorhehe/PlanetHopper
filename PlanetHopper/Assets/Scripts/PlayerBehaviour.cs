﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D r;
    private int hp;
    private bool canJump;
    private GameObject gameController;


    Vector2 startPosition;

    // Use this for initialization
    void Start ()
    {
        r = GetComponent<Rigidbody2D>();

        gameController = GameObject.Find("GameController");

        hp = 100;
        canJump = true;

        //Methods
        gameController.GetComponent<GameBehaviour>().startGame(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Methods
        jump();
        hpControl();

	}

    public void jump ()
    {
        Vector2 mouseVectorPosition = Camera.main.ScreenToViewportPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        
        if (Input.GetKeyDown(KeyCode.Mouse0) && canJump)
        {
            startPosition = mouseVectorPosition;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && canJump)
        {
            Vector2 heading = startPosition - mouseVectorPosition;
            float dist = Vector2.Distance(startPosition, mouseVectorPosition);
            
            if(dist <= 0.45f)
            {
                Vector2 direction = heading / dist;
                r.AddForce(direction * dist * 1000);
                
            }
            else if (dist > 0.45)
            {
                Vector2 direction = heading / dist;
                r.AddForce(direction * 0.45f * 1000);
            }
            canJump = false;
        }
    }

    public void hpControl()
    {
        if (hp <= 0)
        {
            gameController.GetComponent<GameBehaviour>().startGame(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            hp -= 10;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Portal")
        {
            gameController.GetComponent<GameBehaviour>().startGame(false);
        }
    }
}