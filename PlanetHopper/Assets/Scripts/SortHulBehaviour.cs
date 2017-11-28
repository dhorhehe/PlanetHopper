using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortHulBehaviour : MonoBehaviour
{
    private GameObject sorthul2;
    private GameObject player;
    private int works;
    private float timer;

	// Use this for initialization
	void Start ()
    {
        sorthul2 = GameObject.Find("Sorthul2");
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            resetWorks();
        }
    }

    public int getWorks()
    {
        return works;
    }

    public void resetWorks()
    {
        works = 0;
    }

    public void teleport()
    {
        Vector2 speed = player.GetComponent<Rigidbody2D>().velocity;
        player.transform.position = new Vector2(sorthul2.transform.position.x, sorthul2.transform.position.y);
        player.GetComponent<Rigidbody2D>().velocity = speed;
        works++;
        Debug.Log(works);

        if (works == 1)
        {
            timer = 0.2f;

            
        }
    }

    public void teleport2()
    {
        Vector2 speed = player.GetComponent<Rigidbody2D>().velocity;
        player.transform.position = new Vector2(transform.position.x, transform.position.y);
        player.GetComponent<Rigidbody2D>().velocity = speed;
        works++;

        if (works == 1)
        {
            timer = 0.2f;
        }
    }


}
