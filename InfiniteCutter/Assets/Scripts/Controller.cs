using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,1.2f,0);
	}
	
	// Update is called once per frame
	void Update () {
        Control();
	}

    void Control() {
        if (Input.GetKeyDown("right")) {
            gameObject.transform.Translate(1.5f, 0, 0);     
        }

        if (Input.GetKeyDown("left")) {
            gameObject.transform.Translate(-1.5f, 0, 0);
        }
    }
}
