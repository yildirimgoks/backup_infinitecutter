﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public Transform[] NextTile;
	public Collider2D Player;
    private Vector2 movedTile;

	// Use this for initialization
	void Start () {
		//Physics2D.IgnoreCollision (GetComponent<Collider2D>(), Player);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {

            movedTile = new Vector2(transform.position.x, transform.position.y+12);
            NextTile[1].position = movedTile;
           
		}
	}
}
