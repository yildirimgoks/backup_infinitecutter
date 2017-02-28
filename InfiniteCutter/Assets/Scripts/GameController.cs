using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public UIController UIController;
	public Controller Controller;
    public AudioClip MainTheme;
    public AudioClip Click;
    public Button SoundButton;
    public Sprite[] SoundSprites;
    AudioSource AudioSource;
    
    

	public float DistanceMultiplier;
	public float KillMultiplier;
	private int _score;
	private int _highScore;
    bool muted = false;

	public bool TierSystemOn;
	public int Tier;
	public int TierInterval;
	public GameObject[] TierTiles;
	public GameObject[] TierEnemies;

	public ObstacleSpawner ObstacleSpawner;
	public TileSpawner[] TileSpawners;

	// Use this for initialization
	void Start () {
        AudioListener.pause = false;
        _highScore = PlayerPrefs.GetInt ("highScore");
        gameObject.GetComponent<AudioSource>().Play();
		Tier = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (TierSystemOn) {
			if (Controller.GetDistance () == TierInterval * (Tier + 1)) {
				Tier += 1;
				ObstacleSpawner.OnTierChange ();
				foreach (var spawner in TileSpawners) {
					spawner.OnTierChange ();
				}
			}
		}
	}

	public void EndRound(){
		ObstacleSpawner.isSpawning=false;
        /* foreach (var untouchable in FindObjectsOfType<Untouchables>()) {
			if (untouchable.gameObject.GetComponent<Rigidbody2D> ()) {
				untouchable.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			}
		} */

        foreach (var untouchable in FindObjectsOfType<Untouchables>())
        {
            Destroy(untouchable.gameObject);
        }

        Controller.StopRunning();
		Controller.gameObject.GetComponent<Animator> ().SetTrigger ("Dead");
		_score = (int)(Controller.GetDistance () * DistanceMultiplier + Controller.GetKillCount () * KillMultiplier);
		UIController.EndRound ();
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

	public void ResetTier(){
		Tier = 0;
		ObstacleSpawner.OnTierChange ();
		foreach (var spawner in TileSpawners) {
			spawner.OnTierChange ();
		}
	}

    public int GetScore() {
        return _score;
    }

    public bool isHighScore() {
        return _score > _highScore;
    }

    public int GetHighScore()
    {
        _highScore = PlayerPrefs.GetInt("highScore");
        return _highScore;
    }

	public void StartGame(){
		UIController.StartGame ();
		Controller.StartRunnning ();
		ObstacleSpawner.isSpawning = true;
        StartCoroutine(ObstacleSpawner.SpawnWithTutorial());
    }

    public void Clicker() {
        AudioSource = gameObject.GetComponent<AudioSource>();
        AudioSource.PlayOneShot(Click);
    }

    public void SoundSetting(){
        if (!muted) {
            AudioListener.pause = true;
            muted = true;
            SoundButton.image.overrideSprite = SoundSprites[0];
        }

        else if (muted) {
            AudioListener.pause = false;
            muted = false;
            SoundButton.image.overrideSprite = SoundSprites[1];
        }
    }
}
