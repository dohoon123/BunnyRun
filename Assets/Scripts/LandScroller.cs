using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScroller : MonoBehaviour
{
    Vector2 moveSpeed;

    Vector2 offset;
    Material material;

    bool isSlide = false;

    void Start() {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update() {
        SetMoveSpeed();
        Slide();
    }

    void SetMoveSpeed() {
        moveSpeed.x = GameManager.instance.gameSpeed * 1.5f;
    }

    void Slide(){
        if(!isSlide) { return; }
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

    public void StartSlide() { isSlide = true; }
    public void StopSlide()  { isSlide = false; }
}
