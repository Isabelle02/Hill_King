using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; set; }

    [SerializeField] RocketMover player1;
    [SerializeField] RocketMover player2;
    [SerializeField] private Text textExitCount1;
    [SerializeField] private Text textExitCount2;

    public string Player1Name;
    public string Player2Name;

    void Awake()
    {
        Instance = this;
        Player1Name = player1.gameObject.name;
        Player2Name = player2.gameObject.name;
        player1.OnExitCountChanged += OnPlayer1ExitCountChanged;
        player2.OnExitCountChanged += OnPlayer2ExitCountChanged;
    }

    public int GetWinner()
    {
        if (player1.ExitCount == player2.ExitCount)
            return 0;

        return player1.ExitCount > player2.ExitCount ? 2 : 1;
    }

    void OnDestroy()
    {
        Instance = null;
    }

    void OnPlayer1ExitCountChanged()
    {
        textExitCount1.text = player1.ExitCount.ToString();
    }

    void OnPlayer2ExitCountChanged()
    {
        textExitCount2.text = player2.ExitCount.ToString();
    }

    public void ResetExit()
    {
        player1.ExitCount = 0;
        player2.ExitCount = 0;
        player1.ResetPos();
        player2.ResetPos();
    }
}
