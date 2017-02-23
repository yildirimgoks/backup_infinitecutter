using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {


    public GameObject[] obj;
	public Controller controller;
    public float spawnMin = 1;
    public float spawnMax = 2f;
	private float _tileLength;
    public GameObject Player;
    private Vector2 playerPosition;

	// Use this for initialization
	void Start () {
		_tileLength = obj [0].transform.lossyScale.x;
        Spawn();
	}
	
	public void Spawn () {
        Instantiate(obj[Random.Range(0,obj.Length)],transform.position,Quaternion.identity);
		Invoke("Spawn", _tileLength/controller.GetSpeed());
	}

    /* public void NewSpawner() {
        playerPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);


    } */
}
