using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;

    [SerializeField] private GamePlayView view;

    private void Awake()
    {
        player1.OnFell += OnPlayer1Fell;
        player2.OnFell += OnPlayer2Fell;

        view.OnRestart += OnRestart;
        view.OnExit += OnExit;
        
        view.Init(player1.GetName(), player2.GetName());
    }

    private void OnPlayer1Fell()
    {
        UpdateScoreViews();
        player1.ResetPos();
    }
    private void OnPlayer2Fell()
    {
        UpdateScoreViews();
        player2.ResetPos();
    }

    private void UpdateScoreViews()
    {
        view.UpdateScoreViews(player1.GetScore(), player2.GetScore());
    }

    private void OnRestart()
    {
        player1.ResetPlayer();
        player2.ResetPlayer();
        
        UpdateScoreViews();
    }
    private void OnExit()
    {
        
#if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;
        
#else

        Application.Quit();
        
#endif
        
    }
}
