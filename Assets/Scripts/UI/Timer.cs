using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Timer : MonoBehaviour
{
    public event Action OnTimeEnded;
    
    [SerializeField] private int time;
    [SerializeField] private Text textTime;

    private int _currentTime;
    private Coroutine _timeLoop;

    public void StartTimer()
    {
        if(_timeLoop != null)
            StopCoroutine(_timeLoop);
        
        _currentTime = time;
        _timeLoop = StartCoroutine(TimeController());
    }
    
    IEnumerator TimeController()
    {
        textTime.text = _currentTime.ToString();
        
        while (_currentTime > 0)
        {
            yield return new WaitForSeconds(1);
            _currentTime--;
            textTime.text = _currentTime.ToString();
        }
        
        OnTimeEnded?.Invoke();
    }
}
