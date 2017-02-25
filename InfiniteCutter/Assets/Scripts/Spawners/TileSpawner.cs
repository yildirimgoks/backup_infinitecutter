using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {


    public GameObject[] obj;
	public Controller controller;
    public float spawnMin = 1;
    public float spawnMax = 2f;
	private float _tileLength;
    public GameObject Camera;
    private Vector2 spawnPosition;
    private Vector2 spawnPlaceDelta;

	// Use this for initialization
	void Start () {
		_tileLength = obj [0].transform.lossyScale.x;
        spawnPlaceDelta = new Vector2(gameObject.transform.position.x - Camera.transform.position.x, gameObject.transform.position.y - Camera.transform.position.y);
        Spawn();
	}
	
	public void Spawn () {
        spawnPosition = new Vector2(Camera.transform.position.x + spawnPlaceDelta.x, Camera.transform.position.y + spawnPlaceDelta.y);
        Instantiate(obj[Random.Range(0,obj.Length)],spawnPosition,Quaternion.identity);
		Invoke("Spawn", _tileLength/controller.GetSpeed());
	}

    /* public void NewSpawner() {
        playerPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);


    } */
}
