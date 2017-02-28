using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float startingSpeed;
	private float _speed;
	public Vector2 PlayerVelocity;
	private int _lane;
	private Vector3 _startingPlace;
    Animator _animator;
    public AudioClip LaneChange;
    public AudioClip SwordHit;
    public ParticleSystem bloodEffect;
    public GameObject[] TileTrio;
    private Vector2[] tileTrioPosition;

	private int _killedEnemies;
		
	// Use this for initialization
	void Start () {
        for (int i = 0; i < TileTrio.Length; i++) {
            tileTrioPosition[i] = new Vector2(TileTrio[i].transform.position.x, TileTrio[i].transform.position.y);
        }

		_startingPlace=transform.position;
		_speed = startingSpeed;
		PlayerVelocity = new Vector2(0,_speed);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		_lane = 0;
        GameObject.Find("SwipeController").GetComponent<SwipeControl>().SetMethodToCall(MyCallbackMethod);
    }
	
	// Update is called once per frame
	void Update () {
        //SetSpeedTo(Time.deltaTime+_speed);
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
                    gameObject.GetComponent<AudioSource>().PlayOneShot(LaneChange);
                    gameObject.transform.Translate(-1.5f, 0, 0);
                    _lane -= 1;
                }
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_RIGHT:
                if (_lane != 1)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(LaneChange);
                    gameObject.transform.Translate(1.5f, 0, 0);
                    _lane += 1;
                }
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_TOUCH:
                _animator = gameObject.GetComponent<Animator>();
                _animator.SetTrigger("Attack");
                Collider2D[] CollidersInFront = Physics2D.OverlapAreaAll(new Vector2(transform.position.x - 0.3f, transform.position.y), new Vector2(transform.position.x + 0.5f, transform.position.y + 1.5f));
                foreach (Collider2D collided in CollidersInFront)
                {
                    if (collided.gameObject.tag == "Enemy")
                    {
                        gameObject.GetComponent<AudioSource>().PlayOneShot(SwordHit);
                        //ParticleSystem blood = Instantiate(bloodEffect) as ParticleSystem;
                        ParticleSystem blood = ParticlePooler.current.GetPooledParticle();
                        blood.transform.position = collided.transform.position;
                        blood.Play();
                        Invoke("ParticlePooler.current.DestroyParticle(blood)", 2f);
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
                gameObject.GetComponent<AudioSource>().PlayOneShot(LaneChange);
                gameObject.transform.Translate (1.5f, 0, 0);
				_lane += 1;
			}    
        }

        if (Input.GetKeyDown("left")) {
			if (_lane != -1) {
                gameObject.GetComponent<AudioSource>().PlayOneShot(LaneChange);
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
                    gameObject.GetComponent<AudioSource>().PlayOneShot(SwordHit);
                    //ParticleSystem blood = Instantiate(bloodEffect) as ParticleSystem;
                    ParticleSystem blood = ParticlePooler.current.GetPooledParticle();
                    blood.transform.position = collided.transform.position;
                    blood.Play();
                    Invoke("ParticlePooler.current.DestroyParticle(blood)", 2f);
                    Destroy(collided.gameObject);
                    _killedEnemies += 1;
                }
            }
        }

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit ();
		}
    }

	public void SetSpeedTo(float speed){
		_speed = speed;
		PlayerVelocity.y = speed;
		PlayerVelocity.x = 0f;
		gameObject.GetComponent<Rigidbody2D> ().velocity = PlayerVelocity;
	}

	public float GetSpeed(){
		return startingSpeed;//should change
	}

	public void ResetPlayer(){
        for (int i = 0; i < TileTrio.Length; i++) {
            TileTrio[i].transform.position = tileTrioPosition[i];
        }
        transform.position=_startingPlace;
		_lane = 0;
		_killedEnemies = 0;
		//gameObject.GetComponent<Animator> ().SetBool ("Start", true);
		SetSpeedTo(startingSpeed);
	}

	public int GetDistance(){
		return (int)(transform.position.y - _startingPlace.y);
	}

	public int GetKillCount(){
		return _killedEnemies;
	}

	public void StartRunnning(){
		//gameObject.GetComponent<Animator> ().SetBool ("Start", true);
		gameObject.GetComponent<Rigidbody2D> ().velocity = PlayerVelocity;
	}

	public void StopRunning(){
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		//gameObject.GetComponent<Animator> ().SetBool ("Start", false);
	}
}
