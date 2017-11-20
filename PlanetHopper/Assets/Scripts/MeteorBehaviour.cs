using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    private int direction;


    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (direction == 0)
        {
            transform.Translate(new Vector2(0,-5 * Time.deltaTime));
        }
        else if (direction == 1)
        {
            transform.Translate(new Vector2(0, 5 * Time.deltaTime));
        }
        else if (direction == 2)
        {
            transform.Translate(new Vector2(-5 * Time.deltaTime, 0));
        }
        else if (direction == 3)
        {
            transform.Translate(new Vector2(5 * Time.deltaTime, 0));
        }

    }

    public void movement()
    {
        if (transform.position.y > 7)
        {
            //Top spawn
            direction = 0;
        }

        if (transform.position.y < -7)
        {
            //Bottom spawn
            direction = 1;
        }

        if (transform.position.x > 15)
        {
            //Right spawn
            direction = 2;
        }

        if (transform.position.x < -15)
        {
            //Left spawn
            direction = 3;
        }
    }
}
