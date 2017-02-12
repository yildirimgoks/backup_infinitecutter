using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Untouchables : MonoBehaviour {

    public Button ReplayButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag=="Player") {
            ReplayButton.gameObject.SetActive(true);
        }
    }
}
