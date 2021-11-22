using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private Text textResult;

    public void SetTextWinner(int winner)
    {
        if (winner == 0) textResult.text = "Drawn Game";
        else if (winner == 1) textResult.text = $"{PlayerManager.Instance.Player1Name}\nwon!";
        else textResult.text = $"{PlayerManager.Instance.Player2Name}\nwon!";
    }

    public void RestartGame()
    {
        PlayerManager.Instance.ResetExit();
        TimeManager.Instance.ResetTime();
        Destroy(gameObject);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
