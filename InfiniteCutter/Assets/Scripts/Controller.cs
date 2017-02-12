using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float startingSpeed;
	private float _speed;
	private Vector2 _velocity;
	private int _lane;
	private Vector3 _startingPlace;
    Animator _animator;

	private int _killedEnemies;
		
	// Use this for initialization
	void Start () {
		_startingPlace=transform.position;
		_speed = startingSpeed;
		_velocity = new Vector2(0,_speed);
		gameObject.GetComponent<Rigidbody2D> ().velocity = _velocity;
		_lane = 0;
        GameObject.Find("SwipeController").GetComponent<SwipeControl>().SetMethodToCall(MyCallbackMethod);
    }
	
	// Update is called once per frame
	void Update () {
        Control();
	}

    //Touch Controls
    private void MyCallbackMethod(SwipeControl.SWIPE_DIRECTION iDirection)
    {
        switch (iDirection)
        {

            case SwipeControl.SWIPE_DIRECTION.SD_LEFT:
                if (_lane != -1)
                {
                    gameObject.transform.Translate(-1.5f, 0, 0);
                    _lane -= 1;
                }
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_RIGHT:
                if (_lane != 1)
                {
                    gameObject.transform.Translate(1.5f, 0, 0);
                    _lane += 1;
                }
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_TOUCH:
                _animator = gameObject.GetComponent<Animator>();
                //_animator.ResetTrigger("backwalk");
                _animator.SetTrigger("Attack");
                Collider2D[] CollidersInFront = Physics2D.OverlapAreaAll(new Vector2(transform.position.x - 0.5f, transform.position.y), new Vector2(transform.position.x + 0.5f, transform.position.y + 1.5f));
                foreach (Collider2D collided in CollidersInFront)
                {
                    if (collided.gameObject.tag == "Enemy")
                    {
                        Destroy(collided.gameObject);
					_killedEnemies += 1;
                    }
                }
                break;
        }
    }

    //Keyboard Controls
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
			//_animator.ResetTrigger("backwalk");
            _animator.SetTrigger("Attack");
            Collider2D[] CollidersInFront = Physics2D.OverlapAreaAll(new Vector2(transform.position.x - 0.5f, transform.position.y), new Vector2(transform.position.x + 0.5f, transform.position.y + 1.5f));
            foreach(Collider2D collided in CollidersInFront) {
                if (collided.gameObject.tag=="Enemy")
                {
                    Destroy(collided.gameObject);
					_killedEnemies += 1;
                }
            }
        }
    }

	public void SetSpeedTo(float speed){
		_speed = speed;
		_velocity.y = speed;
		_velocity.x = 0f;
		gameObject.GetComponent<Rigidbody2D> ().velocity = _velocity;
	}

	public float GetSpeed(){
		return startingSpeed;//should change
	}

	public void ResetPlayer(){
		transform.position=_startingPlace;
		_lane = 0;
		SetSpeedTo(startingSpeed);
		_killedEnemies = 0;
	}

	public int GetDistance(){
		return (int)(transform.position.y - _startingPlace.y);
	}

	public int GetKillCount(){
		return _killedEnemies;
	}
}
