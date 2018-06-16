using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    float speed;

	// Use this for initialization
	void Start () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        GameController.score += 1;
    }

    // Update is called once per frame
    void Update () {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        if(transform.position.y >= 10 | GameController.isGameOver)
        {
            Destroy(gameObject);
        }
	}
}
