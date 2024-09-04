using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    IEnumerator spawnCoroutine;
    [SerializeField] float spawnDelayTime = 2.0f;

    InteractableObjectSpawner[] objectSpawners;

    private void Start() {
        SetLocation();

        spawnCoroutine = Spawn();
        objectSpawners = transform.GetComponentsInChildren<InteractableObjectSpawner>();
    }

    public void StartSpawn(){
        if (spawnCoroutine != null) {
            StartCoroutine(spawnCoroutine);
        }
    }

    public void StopSpawn() {
        if (spawnCoroutine != null) {
            StopCoroutine(spawnCoroutine);
        }

        foreach (InteractableObjectSpawner ob in objectSpawners) {
            ob.StopSpawn();
        }
    }

    IEnumerator Spawn(){

        int spawnerCount = objectSpawners.Length;

        while (true) {
            
            int selectNumber = UnityEngine.Random.Range(0, spawnerCount);
            
            objectSpawners[selectNumber].Spawn();

            yield return new WaitForSeconds(spawnDelayTime);
        }
    }

    private void SetLocation() {
        float xLoc = GetPositionXOutOfScreen();
        transform.SetPositionAndRotation(new Vector2(xLoc, transform.position.y), transform.rotation);
    }

    private float GetPositionXOutOfScreen() {
        Vector2 pos = new(1.0f, 0.5f);
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(pos);
        float xLoc = edgeVector.x * 2.0f;
        //float yLoc = edgeVector.y;
        return xLoc;
    }


}
