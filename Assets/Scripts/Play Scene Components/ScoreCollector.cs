using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Obstacle")) {
            GameManager.instance.AddScore(1);
        }
    }

    public void AddScore() {
        //GameManager.instance.AddScore();
    }
}
