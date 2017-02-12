using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public UIController UIController;
	public Controller Controller;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EndRound(){
		UIController.EndRound (Controller.GetDistance(),Controller.GetKillCount());
		Time.timeScale = 0;
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
		Time.timeScale = 1;
	}

	public void StartGame(){
		Time.timeScale = 1;
		UIController.StartGame ();
	}
		
}
