using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField]
	GameObject player;

	[SerializeField]
	GameObject enemy;

	[SerializeField]
	GameObject tutorialObject;

	[SerializeField]
	GameObject levelObject;

	[SerializeField]
	GameObject startObject;

	[SerializeField]
	GameObject gameoverObject;

	[SerializeField]
	GameObject winObject;

	[SerializeField]
	GameObject livesObject;

	[SerializeField]
	GameObject scoreObject;

	[SerializeField]
	GameObject enemyParent;

	[SerializeField]
	GameObject startAgainObject;

	[SerializeField]
	GameObject coins;

	[SerializeField]
	GameObject tomatoes;

	[SerializeField]
	GameObject immunityObject;

	[SerializeField]
	GameObject nextLevelObject;

	Text livesText;
	Text scoreText;
	Text levelText;

	public static int score;
	public static int lives;

	int level;

	public static GameObject playerToRef;

	public static bool playerHasEatenTomato;

	public static bool isGameOver;
	public static bool hasWon;
	public static bool isImmune;

	List<GameObject> enemies;

	bool isFirstTime;

	// Use this for initialization
	void Start () {
		
		livesText = livesObject.GetComponent<Text> ();
		scoreText = scoreObject.GetComponent<Text> ();
		levelText = levelObject.GetComponent<Text> ();
		enemies = new List<GameObject> ();

		isFirstTime = true;

		GameStart (1);


	}

	private void GameStart(int level){
		score = 0;
		lives = 3;
		this.level = level;
		isGameOver = false;
		hasWon = false;
		isImmune = false;
		playerHasEatenTomato = false;

		scoreText.text = "Score: " + score;
		livesText.text = "Lives: " + lives;

		gameoverObject.SetActive (false);
		startAgainObject.SetActive (false);
		nextLevelObject.SetActive (false);
		winObject.SetActive (false);
		Instantiate (coins);
		Instantiate (tomatoes);

		if (isFirstTime == true) {
			StartCoroutine (StartCo());
		} else {
			StartCoroutine (NextLevelCo());
		}

	}

	private void MakeLevel(){

		switch (level) {
		case 1:
			playerToRef = Instantiate (player, new Vector3 (-5.29f, 3.48f, 0), Quaternion.identity);
			enemies.Add(Instantiate (enemy, new Vector3 (0.055f, -0.056f, 0), Quaternion.identity, enemyParent.transform));
			enemies.Add(Instantiate (enemy, new Vector3 (3.47f, -0.4742275f, 0), Quaternion.identity, enemyParent.transform));
			enemies.Add(Instantiate (enemy, new Vector3 (-0.59f, -1.19f, 0), Quaternion.identity, enemyParent.transform));
			enemies.Add(Instantiate (enemy, new Vector3 (5.275783f, -3.289954f, 0), Quaternion.identity, enemyParent.transform));
				break;
		case 2:
			playerToRef = Instantiate (player, new Vector3 (-5.29f, 3.48f, 0), Quaternion.identity);
			enemies.Add (Instantiate (enemy, new Vector3 (0.055f, -0.056f, 0), Quaternion.identity, enemyParent.transform));
			enemies.Add (Instantiate (enemy, new Vector3 (3.47f, -0.4742275f, 0), Quaternion.identity, enemyParent.transform));
			enemies.Add (Instantiate (enemy, new Vector3 (-0.59f, -1.19f, 0), Quaternion.identity, enemyParent.transform));
			enemies.Add (Instantiate (enemy, new Vector3 (5.275783f, -3.289954f, 0), Quaternion.identity, enemyParent.transform));
			enemies.Add (Instantiate (enemy, new Vector3 (5.219433f, 3.463164f, 0), Quaternion.identity, enemyParent.transform));
			enemies.Add (Instantiate (enemy, new Vector3 (-5.063617f, -3.417782f, 0), Quaternion.identity, enemyParent.transform));
			enemies.Add (Instantiate (enemy, new Vector3 (0.6150826f, -2.496912f, 0), Quaternion.identity, enemyParent.transform));
			enemies.Add (Instantiate (enemy, new Vector3 (0.6150826f, 0.4703361f, 0), Quaternion.identity, enemyParent.transform));
			break;
		}


	}

	IEnumerator StartCo(){

		tutorialObject.SetActive (true);
		yield return new WaitForSeconds (4);
		tutorialObject.SetActive (false);
		levelObject.SetActive (true);
		yield return new WaitForSeconds (2);
		startObject.SetActive (true);
		yield return new WaitForSeconds (1);
		levelObject.SetActive (false);
		startObject.SetActive (false);
		MakeLevel ();
	}

	IEnumerator NextLevelCo(){
		levelText.text = "Level " + level;
		levelObject.SetActive (true);
		yield return new WaitForSeconds (2);
		startObject.SetActive (true);
		yield return new WaitForSeconds (1);
		levelObject.SetActive (false);
		startObject.SetActive (false);
		MakeLevel ();
	}

	// Update is called once per frame
	void Update () {
		if (isGameOver == false && hasWon == false) {
			scoreText.text = "Score: " + score;
			livesText.text = "Lives: " + lives;
		} else if (isGameOver == true) {
			DestroyAll ();
			gameoverObject.SetActive (true);
			startAgainObject.SetActive (true);
			immunityObject.SetActive (false);

			if (Input.GetKey ("space")) {
				isFirstTime = false;
				GameStart (1);
			}
		} else if (hasWon == true) {
			DestroyAll ();
			winObject.SetActive (true);
			nextLevelObject.SetActive (true);

			if (Input.GetKey ("space")) {
				isFirstTime = false;
				GameStart (level+1);
			}
		}

		if (lives == 0) {
			isGameOver = true;
		}
		if (score == 61) {
			hasWon = true;
		}

		if (isImmune) {
			immunityObject.SetActive (true);
		} else {
			immunityObject.SetActive (false);
		}

	}

	private void DestroyAll(){
		foreach (GameObject enemy in enemies) {
			Destroy (enemy);
		}
		Destroy (playerToRef);
	}
}
