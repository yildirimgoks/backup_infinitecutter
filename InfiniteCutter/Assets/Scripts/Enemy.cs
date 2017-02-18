using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float EnemySpeed;
    private Vector2 _enemyVelocity;
	// Use this for initialization

	void Start () {
        _enemyVelocity = new Vector2(0, -EnemySpeed);
        gameObject.GetComponent<Rigidbody2D>().velocity = _enemyVelocity;
            }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetSpeed(){
		//_enemyVelocity.y = -EnemySpeed;
		gameObject.GetComponent<Rigidbody2D>().velocity = _enemyVelocity;
	}
}
