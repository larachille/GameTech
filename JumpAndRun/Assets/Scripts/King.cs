using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour {

    [SerializeField]
    float speed;

    [SerializeField]
    float jumpHeight;

    [SerializeField]
    int maxForce;

    Rigidbody2D rBody;

    Animator animator;

	bool jump;
	bool left;
	bool right;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

		float h = Input.GetAxis ("Horizontal");

		if (Input.GetKey ("a")) {
			if (h * rBody.velocity.x < maxForce) {
				rBody.AddForce (Vector2.left * speed);
				animator.SetBool ("isStanding", false);

			} else {
				rBody.velocity = new Vector2 (Mathf.Sign (rBody.velocity.x) * maxForce, rBody.velocity.y);
			}
		}

		if (Input.GetKey ("d")) {
			if (h * rBody.velocity.x < maxForce) {
				rBody.AddForce (Vector2.right * speed);
				animator.SetBool ("isStanding", false);
			}
			else {
				rBody.velocity = new Vector2 (Mathf.Sign (rBody.velocity.x) * maxForce, rBody.velocity.y);
			}
		}
		if (Input.GetKeyDown("w") | Input.GetKeyDown("space"))
		{
			rBody.AddForce (Vector2.up * speed * jumpHeight);
			animator.SetBool ("isStanding", false);

		}
    }


    private bool TooMuchForce()
    {
        if(rBody.velocity.magnitude >= maxForce)
        {
            return true;
        }
        return false;
    }
}
