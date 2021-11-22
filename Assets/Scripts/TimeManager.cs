using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; set; }
    [SerializeField] private int time;
    [SerializeField] private Text textTime;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Canvas canvas;

    private int oldTime;

    void Awake()
    {
        Instance = this;
        oldTime = time;
        StartCoroutine(TimeController());
    }
    void OnDestroy()
    {
        Instance = null;
    }
    IEnumerator TimeController()
    {
        textTime.text = time.ToString();
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            textTime.text = time.ToString();
        }
        var panel = Instantiate(resultPanel, canvas.transform, false);
        panel.GetComponent<ResultManager>().SetTextWinner(PlayerManager.Instance.GetWinner());
    }
    public void ResetTime()
    {
        time = oldTime;
        StartCoroutine(TimeController());
    }
}
