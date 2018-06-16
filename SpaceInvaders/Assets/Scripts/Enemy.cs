using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	[SerializeField]
	public Material material;

    [SerializeField]
    float speed;

	private bool dissolve = false;

    GameObject player;

	int dissolveTime = 8;
	float burnfactor = 0.74f;
	float decreaseFactor;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
		decreaseFactor = burnfactor / dissolveTime;
	}

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject == player) {
			GameController.isGameOver = true;
		} else {
			dissolve = true;
		}


    }


    // Update is called once per frame
    void Update () {

		if (dissolve) {
			if (dissolveTime > 0) {
				material.SetFloat ("_BurnDistance", burnfactor);
				burnfactor = burnfactor - decreaseFactor;
				dissolveTime = dissolveTime - 1;
			} else {
				Destroy (gameObject);
			}

		}

        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);

        if(transform.position.y <= -7 | GameController.isGameOver)
        {
            Destroy(gameObject);
        }
	}
}
