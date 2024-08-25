using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : InteractableObject
{

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            // if item function added, should check sth more. but now it's just fine
            GameManager.instance.RunGameOverEvent();
        }
    }
}
