using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UnityEvent OnGameStart;
    public UnityEvent OnGameOver;

    public float gameSpeed = 1.0f; 

    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake() {
        instance = this;

        scoreText.text = score.ToString();
    }
    
    public void RunGameStartEvent() {
        OnGameStart?.Invoke();
    }

    public void RunGameOverEvent() {
        OnGameOver?.Invoke();
    }

    public void StartGame() {
        RunGameStartEvent();
    }

    public void AddScore(int inScore) {
        score += inScore;
        scoreText.text = score.ToString();
    }
}
