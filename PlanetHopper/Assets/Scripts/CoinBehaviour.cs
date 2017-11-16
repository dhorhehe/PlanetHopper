using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private GameObject g;

	// Use this for initialization
	void Start ()
    {
        g = GameObject.Find("GameController"); 
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {

            Destroy(gameObject);
            g.GetComponent<GameBehaviour>().addCoins();
        }
    }
}
