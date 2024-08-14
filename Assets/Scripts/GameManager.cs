using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UnityEvent OnGameStart;
    public UnityEvent OnGameOver;

    public float gameSpeed = 1.0f; 

    bool isStart = false;

    void Awake() {
        instance = this;
    }

    void Update() {
        StartGame();
    }

    public void RunGameStartEvent() {
        OnGameStart?.Invoke();
    }

    public void RunGameOverEvent() {
        OnGameOver?.Invoke();
    }

    void StartGame() {
        if (!isStart) {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    isStart = true;
                    RunGameStartEvent();
                }
            }
        }
    }
}
