using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Controller Controller;
	public GameController GameController;
	public GameObject replayButton;
	public Text gameOverText;
	public GameObject startGameButton;
    private Rect _smallerButtonRect;
	public Text scoreLabel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateLabels ();
	}

	public void StartGame(){
		startGameButton.SetActive(false);
	}


	public void StartRound(){
		replayButton.SetActive (false);
		gameOverText.gameObject.SetActive (false);
	}

	public void EndRound(int score, bool isHighScore){
		replayButton.SetActive (true);
		if(isHighScore)
        	gameOverText.text = "High Score!\n " + score.ToString();
		else
			gameOverText.text = "Score\n" + score.ToString();
		gameOverText.gameObject.SetActive (true);
	}

	public void UpdateLabels(){
		scoreLabel.text = ((int)(Controller.GetDistance () * GameController.DistanceMultiplier + Controller.GetKillCount () * GameController.KillMultiplier)).ToString();
	}
}
