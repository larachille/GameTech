using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject player;

	[SerializeField]
	GameObject background;

	[SerializeField]
	GameObject sky;

	[SerializeField]
	GameObject mountain;

	[SerializeField]
	GameObject hills;

	[SerializeField]
	GameObject darkForest;

	[SerializeField]
	GameObject forest;

	Vector3 backgroundPos;
	Vector3 skyPos;
	Vector3 mountainPos;
	Vector3 hillPos;
	Vector3 darkForestPos;
	Vector3 forestPos;

    [SerializeField]
    Vector3 offset;

	// Use this for initialization
	void Start () {
		//backgroundPos = new Vector3(background.transform.position.x,background.transform.position.y,background.transform.position.z);
		backgroundPos = background.transform.position;
		skyPos = sky.transform.position;
		mountainPos = mountain.transform.position;
		hillPos = hills.transform.position;
		darkForestPos = darkForest.transform.position;
		forestPos = forest.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if(player != null)
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z) + offset;
        
	}

	public void resetBackground(){
		background.transform.position = new Vector3 (backgroundPos.x,backgroundPos.y,backgroundPos.z);
		sky.transform.position = new Vector3 (skyPos.x,skyPos.y,skyPos.z);
		mountain.transform.position = new Vector3 (mountainPos.x,mountainPos.y,mountainPos.z);
		hills.transform.position = new Vector3 (hillPos.x,hillPos.y,hillPos.z);
		darkForest.transform.position = new Vector3 (darkForestPos.x,darkForestPos.y,darkForestPos.z);
		forest.transform.position = new Vector3 (forestPos.x,forestPos.y,forestPos.z);
	}
}
