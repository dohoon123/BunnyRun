using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclePrefab;
    List<GameObject> obstacles;

    private void Start() {
        obstacles = new List<GameObject>();
    }


    public void Spawn() {
        int obstacleCount = obstaclePrefab.Count;
        int selectNumber = UnityEngine.Random.Range(0, obstacleCount);

        GameObject obstacle = Instantiate(obstaclePrefab[selectNumber], transform.position, Quaternion.identity);
        obstacles.Add(obstacle);
        Destroy(obstacle, 10);
    }

    public void StopSpawn() {
        foreach (GameObject obstacle in obstacles) {
            obstacle.GetComponent<Obstacle>().StopMove();
        }
    }

}
