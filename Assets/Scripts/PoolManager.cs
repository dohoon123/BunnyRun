using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    List<GameObject> prefabs;
    List<List<GameObject>> pools;

    private void Awake() {
        prefabs = new List<GameObject>();
        pools = new List<List<GameObject>>();
    }

    public void AddGameObject(GameObject prefab) {
        prefabs.Add(prefab);
        pools.Add(new List<GameObject>());
    }

    public GameObject Get(int index) {
        GameObject select = GetGameobject(index);
        
        if (select == null) {
            select = Instantiate(prefabs[index], transform);
            select.SetActive(true);
            pools[index].Add(select);
        }

        return select;
    }

    public GameObject Get(int index, Vector3 position) {
        GameObject select = GetGameobject(index);
        
        if (select == null) {
            select = Instantiate(prefabs[index], position, Quaternion.identity);
            select.SetActive(true);
            pools[index].Add(select);
        }

        select.transform.position = position;
        return select;
    }

    private GameObject GetGameobject(int index) {
        GameObject select = null;

        foreach (GameObject item in pools[index]) {
            if (!item.activeSelf) {
                select = item;
                select.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                select.SetActive(true);
                break;
            }
        }
        return select;
    }

    public List<List<GameObject>> GetPools() {
        return pools;
    }
}
