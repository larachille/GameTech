using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {


    [SerializeField]
    float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("d")) { transform.position += new Vector3(-(Time.deltaTime * speed), 0, 0); }
        
	}
}
