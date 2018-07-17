using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour {

	bool movesRight;
	bool movesLeft;
	bool movesUp;
	bool movesDown;

	int speed;

	Animator animator;

	// Use this for initialization
	void Start () {

		speed = 2;

		transform.position += new Vector3 (0, speed * Time.deltaTime, 0);

		movesRight = false;
		movesLeft = false;
		movesUp = true;
		movesDown = false;

		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (movesUp == true) {
				transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
			}
		if (movesRight == true) {
				transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
			}
		if (movesLeft == true) {
				transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
			}
		if (movesDown == true) {
				transform.position += new Vector3 (0, -speed * Time.deltaTime, 0);
			}
	}

	public void OnCollisionEnter2D(Collision2D collision){

		if (movesUp == true) {
			movesRight = true;
			movesLeft = false;
			movesUp = false;
			movesDown = false;
		} else if (movesRight == true) {
			movesRight = false;
			movesLeft = false;
			movesUp = false;
			movesDown = true;
		} else if (movesLeft == true) {
			movesRight = false;
			movesLeft = false;
			movesUp = true;
			movesDown = false;
		} else if (movesDown == true) {
			movesRight = false;
			movesLeft = true;
			movesUp = false;
			movesDown = false;
		}

		if (collision.gameObject.layer == 11) {
			StartCoroutine (HitSwitch ());
		}
	}

	IEnumerator HitSwitch(){
		animator.SetBool ("hitSomething", true);
		yield return new WaitForSecondsRealtime(1);
		animator.SetBool ("hitSomething", false);
	}

	public int NewNumber(){

		Random rndm = new Random ();

		int number = rndm.Next(0,4);

		return number;
	}


}
	
