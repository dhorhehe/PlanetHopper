using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D r;
    private int hp;
    Vector2 startPosition;

    // Use this for initialization
    void Start ()
    {
        r = GetComponent<Rigidbody2D>();
        hp = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
        jump ();

        //Restart
        if(Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0);
        }
	}

    public void jump ()
    {
        Vector2 mouseVectorPosition = Camera.main.ScreenToViewportPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        
        // Force we want to go with
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startPosition = mouseVectorPosition;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector2 heading = startPosition - mouseVectorPosition;
            float dist = Vector2.Distance(startPosition, mouseVectorPosition);
            
            if(dist <= 0.45f)
            {
                Vector2 direction = heading / dist;
                r.AddForce(direction * dist * 1000);
                Debug.Log("Slow shot");
            }
            else if (dist > 0.45)
            {
                Vector2 direction = heading / dist;
                r.AddForce(direction * 0.45f * 1000);
                Debug.Log("Max shot");
            }
        }
    }

    public void hpControl()
    {
        if (hp <= 0)
        {
            startGame(false);
        }
    }

    public void startGame(bool start)
    {
        int gameControl;

        if (start)
        {
            gameControl = 1;
        }
        else
        {
            gameControl = 0;
        }

        Time.timeScale = gameControl;
    }
}
