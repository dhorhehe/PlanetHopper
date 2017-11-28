using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D r;
    private int hp;
    private bool canJump;
    private GameObject gameController;
    private GameObject pointer;
    private GameObject sortHul;
    private float angleOfStart;
    private float forceOfPlayer;
    private float timer;

    Vector2 startPosition;

    // Use this for initialization
    void Start ()
    {
        r = GetComponent<Rigidbody2D>();

        gameController = GameObject.Find("GameController");
        pointer = GameObject.Find("Pointer");
        sortHul = GameObject.Find("Sorthul");

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
        outOfBounds();
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

    public int getHealth()
    {
        return hp;
    }

    public void hpControl()
    {
        if (hp <= 0)
        {
            //Die
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void outOfBounds()
    {
        if (transform.position.x > 10 ||transform.position.x < -10 || transform.position.y > 8 || transform.position.y < -8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Planet" || other.gameObject.tag == "Sorthul" || other.gameObject.name == "Meteor")
        {
            hp -= 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int y = SceneManager.GetActiveScene().buildIndex;

        if (other.gameObject.name == "Portal")
        {
            SceneManager.LoadScene(y + 1);
        }

        if (sortHul.GetComponent<SortHulBehaviour>().getWorks() == 0 && other.gameObject.name == "TeleportCollider2")
        {
            sortHul.GetComponent<SortHulBehaviour>().teleport2();
        }

        if (sortHul.GetComponent<SortHulBehaviour>().getWorks() == 0 && other.gameObject.name == "TeleportCollider")
        {
            sortHul.GetComponent<SortHulBehaviour>().teleport();
        }
    }
}
