using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPColliderBehaviour : MonoBehaviour
{
    private GameObject sorthul;

	// Use this for initialization
	void Start ()
    {
        sorthul = GameObject.Find("Sorthul");	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            sorthul.GetComponent<SortHulBehaviour>().teleport();
        }
    }
}
