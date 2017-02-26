using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {


    public GameObject[] Tiles;
	public Controller controller;
	public GameController GameController;
    public float spawnMin = 1;
    public float spawnMax = 2f;
	private float _tileLength;
    public GameObject Camera;
    private Vector2 spawnPosition;
    private Vector2 spawnPlaceDelta;

	// Use this for initialization
	void Start () {
		Tiles [0] = GameController.TierTiles [GameController.Tier];
		_tileLength = Tiles [0].transform.lossyScale.x;
        spawnPlaceDelta = new Vector2(gameObject.transform.position.x - Camera.transform.position.x, gameObject.transform.position.y - Camera.transform.position.y);
        Spawn();
	}
	
	public void Spawn () {
        spawnPosition = new Vector2(Camera.transform.position.x + spawnPlaceDelta.x, Camera.transform.position.y + spawnPlaceDelta.y);
        Instantiate(Tiles[Random.Range(0,Tiles.Length)],spawnPosition,Quaternion.identity);
		Invoke("Spawn", _tileLength/controller.GetSpeed());
	}

	public void OnTierChange(){
		Tiles [0] = GameController.TierTiles [GameController.Tier];
	}
    /* public void NewSpawner() {
        playerPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);


    } */
}
