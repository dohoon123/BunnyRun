using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{

    public UnityEvent OnPlayerDead;

    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    private bool isMove = true;

    void Update() {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GameManager.instance.RunGameOverEvent();
        }
    }

    void Move() {
        if (isMove) {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    public void StartMove(){
        isMove = true;
    }

    public void StopMove() {
        isMove = false;
    }
}
