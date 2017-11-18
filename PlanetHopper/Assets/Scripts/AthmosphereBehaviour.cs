using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AthmosphereBehaviour : MonoBehaviour
{
    private PointEffector2D p;

    // Use this for initialization
    void Start()
    {
        p = gameObject.GetComponent<PointEffector2D>();
        colorOfAth();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
     * Changes the color of the athmosphere, based on value of magnitude
     */
    public void colorOfAth()
    {
        if (p.forceMagnitude > -35)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (p.forceMagnitude < -35 && p.forceMagnitude > -75)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (p.forceMagnitude < -75)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
