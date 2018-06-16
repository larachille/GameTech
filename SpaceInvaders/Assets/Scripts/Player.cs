using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject bullet;

    GameObject bulletParent;

    // Use this for initialization
    void Start () {
		bulletParent = GameObject.Find ("Bullets");
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
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity, bulletParent.transform);
        }

        if (GameController.isGameOver)
        {
            Destroy(gameObject);
        }
    }
}
