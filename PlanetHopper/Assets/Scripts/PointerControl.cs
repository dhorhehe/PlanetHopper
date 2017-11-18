using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerControl : MonoBehaviour
{
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        gameObject.transform.localScale = new Vector2(0, 0);

    }
	
	// Update is called once per frame
	void Update ()
    {
        pointerRotation();
        pointerScale();
	}

    public void showPointer(bool show)
    {
        if (show)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void pointerRotation()
    {
        float angleOfPlayer = player.GetComponent<PlayerBehaviour>().getAngle();

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleOfPlayer));
    }

    public void pointerScale()
    {
        gameObject.transform.localScale = new Vector2(player.GetComponent<PlayerBehaviour>().getForce()*10, player.GetComponent<PlayerBehaviour>().getForce()*10);
    }
}
