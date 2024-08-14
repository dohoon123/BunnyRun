using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    public enum PlayerState { E_Idle, E_Land, E_Jump, E_Stop }

    PlayerState playerState;

    JumpComponent jumpComponent;

    SpriteRenderer mySpriterRenderer;
    BoxCollider2D myCollider;

    Animator myAnimator;

    private void Awake() {
        playerState = PlayerState.E_Idle;

        jumpComponent = GetComponent<JumpComponent>();

        mySpriterRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update() {

        if(Input.touchCount <= 0) { return; }
        Touch touch = Input.GetTouch(0);

        switch (playerState) {
            case PlayerState.E_Land:
                if (touch.phase == TouchPhase.Began) { SetJump(); }
                break;
            case PlayerState.E_Jump:
                if (touch.phase == TouchPhase.Began) { jumpComponent.Jump(); }
                break;
            case PlayerState.E_Stop:
                break;
        }
    }

    public void StartRun() {
        playerState = PlayerState.E_Land;
        myAnimator.SetTrigger("Start");
    }

    private void SetJump() {
        jumpComponent.Jump();
        playerState = PlayerState.E_Jump;
        myAnimator.SetTrigger("Jump");
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (playerState == PlayerState.E_Jump) {
            if (other.gameObject.CompareTag("Land")) {
                myAnimator.SetTrigger("Land");
                playerState = PlayerState.E_Land;
                jumpComponent.ResetJump();
            }
        }
    }

    public void CollideWithObstacle() {
        playerState = PlayerState.E_Stop;

        myCollider.enabled = false;
        jumpComponent.DisableRigidbody();
        myAnimator.SetTrigger("Dead");
    }
}
