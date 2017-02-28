using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawner : MonoBehaviour {

	public GameController GameController;
	public GameObject[] Obstacles;
	public float spawnMin;
	public float spawnMax;
	private Transform[] Spawners;
    public Text Countdown;
    public Text Tutorial;

	public bool isSpawning;

	// Use this for initialization
	void Start () {
		for(var i = 0; i < 3; i++) {
			Obstacles [i + 3] = GameController.TierEnemies [(GameController.Tier+1)*i];
		}
        SetLanes();
		isSpawning = false;
		//Spawn();
	}

	public void Spawn () {
		var lane = Random.Range (0, 3);
		Instantiate(Obstacles[Random.Range(0,Obstacles.Length)],Spawners[lane].position,Quaternion.identity);
		if(isSpawning)
			Invoke("Spawn", Random.Range(spawnMin,spawnMax));
        if (!isSpawning) {
            foreach (var untouchable in FindObjectsOfType<Untouchables>()) {
                //untouchable.gameObject.GetComponent<Collider2D>().enabled = false;
                Destroy(untouchable.gameObject);
            }
        }
	}

    public IEnumerator SpawnWithTutorial()    {
        Tutorial.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Tutorial.gameObject.SetActive(false);
        Spawn();
    }

    void SetLanes() {
        Spawners = new Transform[3];
        for (var i = 0; i < transform.childCount; i++)
        {
            Spawners[i] = transform.GetChild(i);
        }
    }

    public IEnumerator SpawnWithDelay() {
        Countdown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Countdown.text = "2";
        yield return new WaitForSeconds(1);
        Countdown.text = " 1";
        yield return new WaitForSeconds(1);
        Countdown.gameObject.SetActive(false);
        isSpawning = true;
        Spawn();
    }

	public void OnTierChange(){
		for(var i = 0; i < 3; i++) {
			Obstacles [i + 3] = GameController.TierEnemies [(GameController.Tier+1)*i];
		}
	}

}
