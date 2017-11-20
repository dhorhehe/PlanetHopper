using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UIController : MonoBehaviour
{
    public Button restartBtn;
    private GameObject c;

	// Use this for initialization
	void Start ()
    {
        restartBtn.onClick.AddListener(TaskOnClick);

        c = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void TaskOnClick()
    {
        c.GetComponent<GameBehaviour>().restartGame();
    }
}
