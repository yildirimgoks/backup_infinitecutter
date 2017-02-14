using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject replayButton;
	public Text gameOverText;
	public GameObject startGameButton;
    private Rect _smallerButtonRect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		startGameButton.SetActive(false);
	}


	public void StartRound(){
		replayButton.SetActive (false);
		gameOverText.gameObject.SetActive (false);
	}

	public void EndRound(int distance, int killCount){
		replayButton.SetActive (true);
        //gameOverText.text = "Game Over\nDistance: " + distance.ToString ()+"\nKill Count: "+killCount.ToString();
        gameOverText.text = "Score: " + distance.ToString();
		gameOverText.gameObject.SetActive (true);
	}
}
