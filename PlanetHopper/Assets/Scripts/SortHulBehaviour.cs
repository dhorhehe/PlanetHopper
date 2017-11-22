using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortHulBehaviour : MonoBehaviour
{
    private float timer;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
     if (timer > 0)
        {
            timer -= Time.deltaTime;
        }   
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        teleport();
    }

    public void teleport()
    {
        timer = 2;
    }
}
