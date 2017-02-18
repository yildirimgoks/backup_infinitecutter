using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public UIController UIController;
	public Controller Controller;
    public AudioClip MainTheme;
    public AudioClip Click;
    AudioSource AudioSource;

	public float DistanceMultiplier;
	public float KillMultiplier;
	private int _score;
	private int _highScore;

	public ObstacleSpawner ObstacleSpawner;

	// Use this for initialization
	void Start () {
		_highScore = PlayerPrefs.GetInt ("highScore");
        gameObject.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void EndRound(){
		ObstacleSpawner.isSpawning=false;
		foreach (var untouchable in FindObjectsOfType<Untouchables>()) {
			if (untouchable.gameObject.GetComponent<Rigidbody2D> ()) {
				untouchable.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			}
		}
		Controller.StopRunning();
		Controller.gameObject.GetComponent<Animator> ().SetTrigger ("Dead");
		_score = (int)(Controller.GetDistance () * DistanceMultiplier + Controller.GetKillCount () * KillMultiplier);
		UIController.EndRound (_score,_score>_highScore);
		if (_score > _highScore) {
			_highScore = _score;
			PlayerPrefs.SetInt ("highScore",_highScore);
		}
	}

	public void StartRound(){
		foreach (var untouchable in FindObjectsOfType<Untouchables>()) {
			Destroy (untouchable.gameObject);
		}

		foreach (var tile in GameObject.FindGameObjectsWithTag("Floor Tile")) {
			Destroy (tile);
		}	

		UIController.StartRound ();
		Controller.ResetPlayer ();
		ObstacleSpawner.isSpawning = true;
		ObstacleSpawner.Spawn ();
	}

	public void StartGame(){
        //AudioSource = gameObject.GetComponent<AudioSource>();
        //AudioSource.Stop();
		UIController.StartGame ();
		Controller.StartRunnning ();
		ObstacleSpawner.isSpawning = true;
		ObstacleSpawner.Spawn ();
        //AudioSource.clip = MainTheme;
        //AudioSource.PlayDelayed(0.5f);
    }

    public void Clicker() {
        AudioSource = gameObject.GetComponent<AudioSource>();
        AudioSource.PlayOneShot(Click);
    }



}
