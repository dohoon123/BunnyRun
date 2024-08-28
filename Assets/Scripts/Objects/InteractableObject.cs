using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] Vector3 direction;

    private float moveSpeed;
    private bool isMove = true;

    void Update() {
        SetMoveSpeed();
        Move();
    }

    void Move() {
        if (isMove) {
            transform.Translate(direction.normalized * moveSpeed * 2.0f * Time.deltaTime);
        }
    }

    public void StartMove() { isMove = true; }
    public void StopMove()  { isMove = false; }

    void SetMoveSpeed() {
        moveSpeed = GameManager.instance.gameSpeed;
    }
}
