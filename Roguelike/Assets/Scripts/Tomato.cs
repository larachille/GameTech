using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collision){

		if (collision.gameObject.layer == 11) {
			GameManager.playerHasEatenTomato = true;
			Destroy (this.gameObject);
		}


	}
}
