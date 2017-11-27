using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPColliderBehaviour : MonoBehaviour
{
    private GameObject sorthul;
    private int works;
    private bool even;

	// Use this for initialization
	void Start ()
    {
        sorthul = GameObject.Find("Sorthul");
        works = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (works == 2)
        {
            works = 0;
        }

        if (other.name == "Player" && works == 1 && name == "TeleportCollider")
        {
            sorthul.GetComponent<SortHulBehaviour>().teleport();
        }

        if (other.name == "Player" && works == 1 && name == "TeleportCollider2")
        {
            sorthul.GetComponent<SortHulBehaviour>().teleport2();
        }
    }*/
}
