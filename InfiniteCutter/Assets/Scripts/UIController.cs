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
    public GameObject soundButton;
    public Text adAsker;
    public GameObject[] adButtons;
    public Text StartScreenHighScore;
    private bool adAsked;
   

	// Use this for initialization
	void Start () {
        adAsked = false;
        StartScreenHighScore.text ="HIGH SCORE:\n" + GameController.GetHighScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateLabels ();
	}

	public void StartGame(){
		startGameButton.SetActive(false);
        soundButton.SetActive(false);
        StartScreenHighScore.gameObject.SetActive(false);
    }


	public void StartRound(){
        soundButton.SetActive(false);
		replayButton.SetActive (false);
		gameOverText.gameObject.SetActive (false);
	}

	public void EndRound(){
        if (!adAsked) {
            AskAd();
        }

        else if(adAsked) {
            ShowReplayPanel();
            adAsked = false;
        }  
    }

	public void UpdateLabels(){
		scoreLabel.text = ((int)(Controller.GetDistance () * GameController.DistanceMultiplier + Controller.GetKillCount () * GameController.KillMultiplier)).ToString();
	}

    public void AskAd() {
        adAsker.gameObject.SetActive(true);
        adButtons[0].SetActive(true);
        adButtons[1].SetActive(true);
        adAsked = true;
    }

    public void CloseAdAsker() {
        adAsker.gameObject.SetActive(false);
        adButtons[0].SetActive(false);
        adButtons[1].SetActive(false);
    }

    public void ShowReplayPanel() {
		GameController.ResetTier ();
        replayButton.SetActive(true);
        if (GameController.isHighScore())
            gameOverText.text = "High Score!\n " + GameController.GetScore().ToString();
        else
            gameOverText.text = "Score\n" + GameController.GetScore().ToString();
        gameOverText.gameObject.SetActive(true);
        soundButton.SetActive(true);
    }
}
