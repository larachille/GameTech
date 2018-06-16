using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    float lastTime;

    [SerializeField]
    float enemySpawnTime;

	[SerializeField]
    GameObject enemyObject;

    [SerializeField]
    GameObject enemyParent;

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    GameObject gameOverObject;

    [SerializeField]
    GameObject scoreObject;

    [SerializeField]
    GameObject restartObject;

    [SerializeField]
    GameObject playerObject;

    [SerializeField]
    int spawnRange;

    public static bool isGameOver;
    public static int score;

    Text gameOverText;
    Text scoreText;

    // Use this for initialization
    void Start () {
        lastTime = Time.time;
        isGameOver = false;
        score = 0;
        scoreText = scoreObject.GetComponent<Text>();
        gameOverObject.SetActive(false);
        restartObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {

        if (!isGameOver)
        {

            float now = Time.time;

            if (now - lastTime >= enemySpawnTime)
            {
                spawnEnemy();
                lastTime = now;
            }

            scoreText.text = "Score: " + score;

        }
        else
        {
            gameOverObject.SetActive(true);
            restartObject.SetActive(true);

            if (Input.GetKeyDown("r"))
            {
                restart();
            }
        }

        
    }

    private void restart()
    {
        Instantiate(playerObject,new Vector3(0,0,0),Quaternion.identity);
        isGameOver = false;
        score = 0;
        gameOverObject.SetActive(false);
        restartObject.SetActive(false);
    }

    void spawnEnemy()
    {
        int min = -(spawnRange/2);
        int max = spawnRange/2;

        int xSpawnPosition = UnityEngine.Random.Range(min,max);

        Instantiate(enemyObject, new Vector3(xSpawnPosition, 10, 0), Quaternion.identity, enemyParent.transform);
    }

    public void gameOver() { }

}
