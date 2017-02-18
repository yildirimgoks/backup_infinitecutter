using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public Transform[] NextTile;
	public Collider2D Player;

	// Use this for initialization
	void Start () {
		//Physics2D.IgnoreCollision (GetComponent<Collider2D>(), Player);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Debug.Log (NextTile[1].position);
			var y = NextTile [1].position.y;
			y = transform.position.y + 12;
			Debug.Log (NextTile[1].position);
		}
	}
}
