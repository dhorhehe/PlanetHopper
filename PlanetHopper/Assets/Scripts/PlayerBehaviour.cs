using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D r;
    private int hp;
    private bool canJump;
    private GameObject gameController;
    private GameObject pointer;
    private float angleOfStart;
    private float forceOfPlayer;


    Vector2 startPosition;

    // Use this for initialization
    void Start ()
    {
        r = GetComponent<Rigidbody2D>();

        gameController = GameObject.Find("GameController");
        pointer = GameObject.Find("Pointer");

        hp = 10;
        canJump = true;

        //Methods
        gameController.GetComponent<GameBehaviour>().startGame(true);
        pointer.GetComponent<PointerControl>().showPointer(false);
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
        Vector2 heading = startPosition - mouseVectorPosition;
        float dist = Vector2.Distance(startPosition, mouseVectorPosition);

        if (Input.GetKeyDown(KeyCode.Mouse0) && canJump)
        {
            startPosition = mouseVectorPosition;
            pointer.GetComponent<PointerControl>().showPointer(true);
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && canJump)
        {
            
            
            if (dist <= 0.45f)
            {
                Vector2 direction = heading / dist;
                r.AddForce(direction * dist * 1000);
                
            }
            else if (dist > 0.45f)
            {
                Vector2 direction = heading / dist;
                r.AddForce(direction * 0.45f * 1000);
            }
            canJump = false;
            pointer.GetComponent<PointerControl>().showPointer(false);
        }

        //Controls rotation of pointer
        angleOfStart = (Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg)-90;

        //Controls the scale of pointer
        if (dist <= 0.45f)
        {
            forceOfPlayer = dist;

        }
        else if (dist > 0.45f)
        {
            forceOfPlayer = 0.45f;
        }

    }

    public float getAngle()
    {
        return angleOfStart;
    }

    public float getForce()
    {
        return forceOfPlayer;
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
            hp -= 1;
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
