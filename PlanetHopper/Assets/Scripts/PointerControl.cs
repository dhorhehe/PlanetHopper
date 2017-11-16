using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerControl : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        pointerRotation();
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
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = (Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg)-90;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
