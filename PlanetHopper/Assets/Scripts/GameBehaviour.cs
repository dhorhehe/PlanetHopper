using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    private int coins;

	// Use this for initialization
	void Start ()
    {
        Debug.Log(coins);
	}
	
	// Update is called once per frame
	void Update ()
    {
		restartGame();
	}

    public int getCoints()
    {
        return PlayerPrefs.GetInt("coins");
    }

    public void addCoins()
    {
        PlayerPrefs.SetInt("coins", coins++);
    }

    public void startGame(bool start)
    {
        int gameControl;

        if (start)
        {
            gameControl = 1;
        }
        else
        {
            gameControl = 0;
        }

        Time.timeScale = gameControl;
    }

    public void restartGame()
    {
        //Restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
