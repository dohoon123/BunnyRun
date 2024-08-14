using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpComponent : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    float curJumpCount = 2;
    const int maxJumpCount = 2;
    [SerializeField] float jumpForce = 1.0f;

    void Awake() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump() {
        if (curJumpCount <= 0) { return; }

        myRigidbody.velocity = Vector2.up * jumpForce;
        curJumpCount--;

        Debug.Log(curJumpCount);
    }

    public void ResetJump() {
        curJumpCount = maxJumpCount;
    }

    public void DisableRigidbody() {
        myRigidbody.isKinematic = false;
        myRigidbody.gravityScale = 0;
    }
}
