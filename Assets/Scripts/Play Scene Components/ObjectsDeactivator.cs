using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDeactivator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.SetActive(false);
    }
}
