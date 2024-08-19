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

    void Awake() {
        instance = this;
    }
/*
    void Update() {
    }
*/
    public void RunGameStartEvent() {
        OnGameStart?.Invoke();
    }

    public void RunGameOverEvent() {
        OnGameOver?.Invoke();
    }

    public void StartGame() {
        RunGameStartEvent();
    }
}
