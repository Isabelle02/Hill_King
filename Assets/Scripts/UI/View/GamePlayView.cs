using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePlayView : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    
    [SerializeField] private Timer timer;
    
    [SerializeField] private PlayerStatsView player1;
    [SerializeField] private PlayerStatsView player2;

    [SerializeField] private ResultPanel resultPanel;

    public event UnityAction OnRestart;
    public event UnityAction OnExit;

    private void Start()
    {
        timer.OnTimeEnded += OnGameEnded;
    }

    public void Init(string player1Name, string player2Name)
    {
        player1.Init(player1Name);
        player2.Init(player2Name);
        
        timer.StartTimer();
    }

    public void UpdateScoreViews(int player1Score, int player2Score)
    {
        player1.UpdateScoreView(player1Score);
        player2.UpdateScoreView(player2Score);
    }

    private void OnGameEnded()
    {
        var panel = Instantiate(resultPanel.gameObject, canvas.transform, false);
        var component = panel.GetComponent<ResultPanel>();

        component.OnExit += OnExitGame;
        component.OnRestart += OnRestartGame;
        
        component.Init(player1, player2);
    }

    private void OnRestartGame()
    {
        OnRestart?.Invoke();
        
        timer.StartTimer();
    }

    private void OnExitGame()
    {
        OnExit?.Invoke();
    }
}
