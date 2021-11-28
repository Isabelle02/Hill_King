using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsView : MonoBehaviour
{
    public Text Score;
    public Text Name;

    public void Init(string playerName)
    {
        Name.text = playerName;
        Score.text = "0";
    }
    
    public void UpdateScoreView(int score)
    {
        this.Score.text = score.ToString();
    }

    public void ResetView()
    {
        Score.text = "0";
    }
}
