using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObjectSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> objectPrefabs;

    PoolManager poolManager;

    private void Start() {
        poolManager = GetComponent<PoolManager>();

        foreach (GameObject prefab in objectPrefabs) {
            poolManager.AddGameObject(prefab);
        }
    }

    public void Spawn() {
        if (objectPrefabs.Count == 0) { return; }
        
        int objectCount = objectPrefabs.Count;
        int selectNumber = UnityEngine.Random.Range(0, objectCount);

        poolManager.Get(selectNumber, transform.position);
    }

    public void StopSpawn() {
        List<List<GameObject>> pools = poolManager.GetPools();

        foreach (List<GameObject> pool in pools) {
            foreach (GameObject interactableObject in pool) {
                interactableObject.GetComponent<InteractableObject>().StopMove();
            }
        }
    }
}
