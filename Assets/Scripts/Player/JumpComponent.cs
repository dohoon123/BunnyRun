using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpComponent : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    float jumpCount = 2;
    [SerializeField] float jumpForce = 1.0f;

    void Awake() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump() {
        if (jumpCount <= 0) { return; }

        myRigidbody.velocity = Vector2.up * jumpForce;
        //jumpCount--;
    }
}
