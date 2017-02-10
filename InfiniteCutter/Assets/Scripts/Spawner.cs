using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject[] obj;
	public Controller controller;
    public float spawnMin = 1;
    public float spawnMax = 2f;
	private float _tileLength;

	// Use this for initialization
	void Start () {
		_tileLength = obj [1].transform.lossyScale.x;
        Spawn();
	}
	
	void Spawn () {
        Instantiate(obj[Random.Range(0,obj.Length)],transform.position,Quaternion.identity);
		Invoke("Spawn", _tileLength/controller.GetSpeed());
	}
}
