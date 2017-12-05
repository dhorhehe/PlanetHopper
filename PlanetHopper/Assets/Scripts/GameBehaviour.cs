using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    private int coins;
    private int spawnBehaviour;
    private GameObject meteor;
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        coins = getCoins();
        meteor = GameObject.Find("Meteor");
        player = GameObject.Find("Player");

        meteor.SetActive(false);
        spawnMeteors();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(coins);

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public int getCoins()
    {
        return PlayerPrefs.GetInt("coins");
    }

    public void addCoins(int value)
    {
        coins = getCoins() + 1;
        PlayerPrefs.SetInt("coins", coins);
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
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnApplicationQuit()
    {
            PlayerPrefs.Save();
    }
    
    public void spawnMeteors()
    {
        spawnBehaviour = Random.Range(0, 4);

        switch (spawnBehaviour)
        {
            case 0:
                meteor.SetActive(true);
                meteor.transform.position = new Vector2(Random.Range(-8,8), 15);
                meteor.GetComponent<MeteorBehaviour>().movement();
                break;
            case 1:
                meteor.SetActive(true);
                meteor.transform.position = new Vector2(Random.Range(-8, 8), -15);
                meteor.GetComponent<MeteorBehaviour>().movement();
                break;
            case 2:
                meteor.SetActive(true);
                meteor.transform.position = new Vector2(-16, Random.Range(-4, 4));
                meteor.GetComponent<MeteorBehaviour>().movement();
                break;
            case 3:
                meteor.SetActive(true);
                meteor.transform.position = new Vector2(16, Random.Range(-4, 4));
                meteor.GetComponent<MeteorBehaviour>().movement();
                break;
            default:
                Debug.Log("Something went wrong");
                break;
        }
    }
}
