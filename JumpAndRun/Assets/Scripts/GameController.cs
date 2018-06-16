using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static bool isGameOver = false;

	public static bool catFound = false;

	public static int score;

    [SerializeField]
	GameObject playerPrefab;

	[SerializeField]
	GameObject coins;

	GameObject currentPlayer;

	[SerializeField]
	GameObject camera;

	[SerializeField]
	GameObject scoreObject;

	[SerializeField]
	GameObject heartObject;

	[SerializeField]
	GameObject finishTextObject;

	GameObject currentCoins;

	Text scoreText;

	// Use this for initialization
	void Start () {
		currentPlayer = Instantiate(playerPrefab);
		currentCoins = Instantiate (coins);
		camera.GetComponent<Follow>().player = currentPlayer; 
		score = 0;
		scoreText = scoreObject.GetComponent<Text> ();
		heartObject.SetActive (false);
		finishTextObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameOver && !catFound)
        {
			scoreText.text = "Score: " + score;
        }
		if(isGameOver)
        {
			ResetGame();
        }
		if (catFound) {
			FinishGame();
		}
	}

	void ResetGame()
	{
		currentPlayer = Instantiate(playerPrefab);
		camera.transform.position = new Vector3 (-3.94f, -3.57f, -10f);
		camera.GetComponent<Follow> ().player = currentPlayer; 
		camera.GetComponent<Follow> ().resetBackground();
		Destroy (currentCoins.gameObject);
		currentCoins = Instantiate (coins);
		score = 0;
		isGameOver = false;
	}

	void FinishGame()
	{
		heartObject.SetActive (true);
		finishTextObject.SetActive (true);
		Destroy(currentPlayer.gameObject);
	}

}