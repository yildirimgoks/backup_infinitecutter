﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

   void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Floor Tile") {
            Destroy(coll.gameObject);
        }
    }
}
