using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScroller : MonoBehaviour
{
    Vector2 moveSpeed;

    Vector2 offset;
    Material material;

    void Start() {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update() {
        SetMoveSpeed();
        //since the land shape is rectangler which ratio is width : 2 and height : 1
        offset = moveSpeed * Time.deltaTime;

        material.mainTextureOffset += offset;
    }

    void SetMoveSpeed() {
        moveSpeed.x = GameManager.instance.gameSpeed;
    }
}
