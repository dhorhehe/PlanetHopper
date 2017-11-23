﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortHulBehaviour : MonoBehaviour
{
    private float timer;
    private GameObject sorthul2;
    private GameObject player;
	// Use this for initialization
	void Start ()
    {
        sorthul2 = GameObject.Find("Sorthul2");
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void teleport()
    {
        timer = 0.5f;
        Vector2 speed = player.GetComponent<Rigidbody2D>().velocity;
        player.transform.position = new Vector2(sorthul2.transform.position.x, sorthul2.transform.position.y);
        player.GetComponent<Rigidbody2D>().velocity = speed;
    }
}
