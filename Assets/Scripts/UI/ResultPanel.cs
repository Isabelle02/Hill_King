using UnityEngine;
using Frame.UI;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    public event UnityAction OnRestart;
    public event UnityAction OnExit;
    
    [SerializeField] private FButton restartButton;
    [SerializeField] private FButton exitButton;
    
    [SerializeField] private Text resultText;

    private void Awake()
    {
        restartButton.OnClick += RestartGame;
        exitButton.OnClick += ExitGame;
    }
    public void Init(PlayerStatsView one, PlayerStatsView two)
    {
        UpdateResultText(one, two);
    }
    
    private void UpdateResultText(PlayerStatsView one, PlayerStatsView two)
    {
        int.TryParse(one.Score.text, out var fScore);
        int.TryParse(two.Score.text, out var sScore);
        
        if (fScore == sScore)
            resultText.text = "Drawn Game";
        
        else if (fScore > sScore)
            resultText.text = $"{two.Name.text}\nwon!";

        else
            resultText.text = $"{one.Name.text}\nwon!";
    }

    private void RestartGame()
    {
        OnRestart?.Invoke();
        
        Destroy(gameObject);
    }

    private void ExitGame()
    {
        OnExit?.Invoke();
    }
}
