using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : InteractableObject
{
    [SerializeField] int myScore = 1;
    [SerializeField] AudioClip itemGetSound;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            AudioManager.instance.PlayClip(itemGetSound);
            GameManager.instance.AddScore(myScore);
            gameObject.SetActive(false);
        }
    }
}
