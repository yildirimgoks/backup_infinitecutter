using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    public static ObjectPooler current;
    public GameObject pooledTile;
    public GameObject pooledObstacle;
    public GameObject pooledDemon;

    public int pooledTileAmount = 5;
    public int pooledObstacleAmount = 5;
    public int pooledDemonAmount = 5;

    List<GameObject> pooledTiles;
    List<GameObject> pooledObstacles;
    List<GameObject> pooledDemons;

    // Use this for initialization

    private void Awake() {
        current = this;
    }

    void Start() {
        PoolTiles();
    }


    //TILE POOLING STARTS
    public void PoolTiles() {
        pooledTiles = new List<GameObject>();
        for (int i = 0; i < pooledTileAmount; i++) {
            GameObject obj = Instantiate(pooledTile) as GameObject;
            obj.SetActive(false);
            pooledTiles.Add(obj);
        }
    }

    public GameObject GetPooledTile() {
        for (int i = 0; i < pooledTiles.Count; i++) {
            if (!pooledTiles[i].activeInHierarchy) {
                return pooledTiles[i];
            }
        }
        return null;
    }
    //TILE POOLING ENDS

    //OBSTACLE POOLING STARTS
    public void PoolObstacles() {
        pooledObstacles = new List<GameObject>();
        for (int i = 0; i < pooledObstacleAmount; i++) {
            GameObject obj = Instantiate(pooledObstacle) as GameObject;
            obj.SetActive(false);
            pooledObstacles.Add(obj);
        }
    }

    public GameObject GetPooledObsacle() {
        for (int i = 0; i < pooledObstacles.Count; i++) {
            if (!pooledObstacles[i].activeInHierarchy) {
                return pooledObstacles[i];
            }
        }
        return null;
    }
    //OBSTACLE POOLING ENDS
    public void PoolDemons() {
        pooledDemons = new List<GameObject>();
        for (int i = 0; i < pooledDemonAmount; i++) {
            GameObject obj = Instantiate(pooledDemon) as GameObject;
            obj.SetActive(false);
            pooledDemons.Add(obj);
        }
    }

    public GameObject GetPooledDemons() {
        for (int i = 0; i < pooledDemons.Count; i++) {
            if (!pooledDemons[i].activeInHierarchy) {
                return pooledDemons[i];
            }
        }
        return null;
    }
    //DEMON POOLING STARTS

    //DMEON POOLING ENDS

    public void DestroyObject(GameObject obj) {
        obj.SetActive(false);
    }
}
