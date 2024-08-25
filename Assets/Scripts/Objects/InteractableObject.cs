using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    
    private bool isMove = true;

    void Update() {
        Move();
    }

    void Move() {
        if (isMove) {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    public void StartMove() { isMove = true; }
    public void StopMove()  { isMove = false; }
}
