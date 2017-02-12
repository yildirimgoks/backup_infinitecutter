using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float speed;
	private Vector2 _velocity;
	private int _lane;
    Animator _animator;
		
	// Use this for initialization
	void Start () {
		_velocity = new Vector2(0,speed);
		gameObject.GetComponent<Rigidbody2D> ().velocity = _velocity;
		_lane = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Control();
	}

    void Control() {
        if (Input.GetKeyDown("right")) {
			if (_lane != 1) {
				gameObject.transform.Translate (1.5f, 0, 0);
				_lane += 1;
			}    
        }

        if (Input.GetKeyDown("left")) {
			if (_lane != -1) {
				gameObject.transform.Translate (-1.5f, 0, 0);
				_lane -= 1;
			}
        }

        if (Input.GetKeyDown("up")) {
            _animator = gameObject.GetComponent<Animator>();
            _animator.ResetTrigger("backwalk");
            _animator.SetTrigger("Attack");
            Collider2D[] CollidersInFront = Physics2D.OverlapAreaAll(new Vector2(transform.position.x - 0.5f, transform.position.y), new Vector2(transform.position.x + 0.5f, transform.position.y + 1.5f));
            foreach(Collider2D collided in CollidersInFront) {
                if (collided.gameObject.tag=="Enemy")
                {
                    Destroy(collided.gameObject);
                }
            }
        }
    }

	void SetSpeedTo(float _speed){
		speed = _speed;
		_velocity.y = _speed;
		gameObject.GetComponent<Rigidbody2D> ().velocity = _velocity;
	}

	public float GetSpeed(){
		return speed;
	}
}
