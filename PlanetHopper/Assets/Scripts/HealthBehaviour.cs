using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    private GameObject[] health = new GameObject[10];
    private GameObject g;

	// Use this for initialization
	void Start ()
    {
        health[0] = GameObject.Find("1health");
        health[1] = GameObject.Find("1health (1)");
        health[2] = GameObject.Find("1health (2)");
        health[3] = GameObject.Find("1health (3)");
        health[4] = GameObject.Find("1health (4)");
        health[5] = GameObject.Find("1health (5)");
        health[6] = GameObject.Find("1health (6)");
        health[7] = GameObject.Find("1health (7)");
        health[8] = GameObject.Find("1health (8)");
        health[9] = GameObject.Find("1health (9)");

        g = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        hpBar();
	}
    
    public void hpBar()
    {
        int hp = g.GetComponent<PlayerBehaviour>().getHealth();

        if (hp < 10)
        {
            health[hp].SetActive(false);
        }
        

        if (hp == 0)
        {
            health[0].SetActive(false);
        }
    }
}
