using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

   void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Floor Tile" || coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Obstacle") {
            Destroy(coll.gameObject);
        }
    }
}
