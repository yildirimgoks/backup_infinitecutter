using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Untouchables : MonoBehaviour {

    public GameObject Player;
    Animator playerAnimator;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag=="Player") {
            Player.GetComponent<Animator>().SetTrigger("Dead");
        Camera.main.GetComponent<GameController> ().EndRound ();
		}

		if (coll.gameObject.tag == "Enemy") {
			Physics2D.IgnoreCollision (coll.collider, GetComponent<Collider2D>());
			coll.gameObject.GetComponent<Enemy> ().SetSpeed ();
		}
    }
}
