using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;

    private void Start() {
        SetLocation();
        StartSpawn();
    }

    private void SetLocation() {
        Vector2 loc = GetPositionOutOfScreen();
        transform.SetPositionAndRotation(loc, transform.rotation);
    }

    private void StartSpawn() {
        StartCoroutine(Spawn());
    }

    public void StopSpawn() {
        StopCoroutine(Spawn());
    }

    IEnumerator Spawn() {

        while (true) {
            // do sth
            GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            Destroy(obstacle, 10);

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
