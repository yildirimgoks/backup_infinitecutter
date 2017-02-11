using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {


	public GameObject[] obj;
	public float spawnMin;
	public float spawnMax;
	private Transform[] Spawners;

	// Use this for initialization
	void Start () {
        SetLanes();
		Spawn();
	}

	void Spawn () {
		var lane = Random.Range (0, 3);
		Instantiate(obj[Random.Range(0,obj.Length)],Spawners[lane].position,Quaternion.identity);
		Invoke("Spawn", Random.Range(spawnMin,spawnMax));
	}

    void SetLanes() {
        Spawners = new Transform[3];
        for (var i = 0; i < transform.childCount; i++)
        {
            Spawners[i] = transform.GetChild(i);
        }
    }
}
