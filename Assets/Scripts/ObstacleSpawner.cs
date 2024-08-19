using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    List<GameObject> obstacles;

    IEnumerator spawnCoroutine;

    private void Start() {
        SetLocation();

        obstacles = new List<GameObject>();
        spawnCoroutine = Spawn();
    }

    private void SetLocation() {
        Vector2 loc = GetPositionOutOfScreen();
        transform.SetPositionAndRotation(loc, transform.rotation);
    }

    public void StartSpawn() {
        StartCoroutine(spawnCoroutine);
    }

    public void StopSpawn() {
        if (spawnCoroutine != null) {
            StopCoroutine(spawnCoroutine);
        }

        foreach (GameObject obstacle in obstacles) {
            obstacle.GetComponent<Obstacle>().StopMove();
        }
    }

    IEnumerator Spawn() {

        while (true) {
            // do sth
            
            GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            obstacles.Add(obstacle);
            Destroy(obstacle, 20);

            yield return new WaitForSeconds(2);
        }
    }

    private Vector2 GetPositionOutOfScreen() {
        Vector2 pos = new(1.0f, 0.5f);
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(pos);
        float xLoc = edgeVector.x;
        float yLoc = edgeVector.y;
        return new Vector2(xLoc, yLoc);
    }
}
