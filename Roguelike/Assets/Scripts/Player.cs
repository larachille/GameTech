using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	Material hitMaterial;

	int speed;

	bool isImmune;

	Material nonhitMaterial;
	Renderer rend;

	Animator animator;

	public bool hasEatenTomato;

	// Use this for initialization
	void Start () {
		speed = 3;
		isImmune = false;
		hasEatenTomato = false;
		rend = GetComponent<Renderer> ();
		nonhitMaterial = rend.material;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey("a"))
		{
			transform.position += new Vector3(-speed * Time.deltaTime,0,0);
		}
		if (Input.GetKey("d"))
		{
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("w"))
		{
			transform.position += new Vector3(0, speed * Time.deltaTime, 0);
		}
		if (Input.GetKey("s"))
		{
			transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
		}

		if (GameManager.playerHasEatenTomato == true) {
			isImmune = true;
			GameManager.isImmune = true;
			rend.material = hitMaterial;
			StartCoroutine (ImmuneCo());
		}
	}

	public void OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.layer == 9 && isImmune == false) {
			if (GameManager.lives <= 0) {
				GameManager.isGameOver = true;
			} else {
				GameManager.lives -= 1;
				isImmune = true;
				GameManager.isImmune = true;
				animator.SetBool ("isScared", true);
				rend.material = hitMaterial;
				StartCoroutine (ImmuneCo());
			}

		}

	}

	IEnumerator ImmuneCo(){
		yield return new WaitForSeconds (3);
		isImmune = false;
		GameManager.isImmune = false;
		animator.SetBool ("isScared", false);
		rend.material = nonhitMaterial;
		GameManager.playerHasEatenTomato = false;
	}


}
