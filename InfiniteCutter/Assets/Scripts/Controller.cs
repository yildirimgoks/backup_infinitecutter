using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float speed;
	private Vector2 _velocity;
	private int _lane;
		
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
