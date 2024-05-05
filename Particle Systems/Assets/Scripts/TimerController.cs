using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    private float _timer;
    [SerializeField] TextMeshProUGUI Score;
    public const string SCORE_KEY = "highscore";
    public float Timer
    {
        get => _timer;

        set
        {
            _timer = value;

            int minutes = Mathf.FloorToInt(Timer / 60.0f);
            int seconds = Mathf.FloorToInt(Timer % 60.0f);

            Score.text = $"TIME {minutes:00}:{seconds:00}";
        }
    }

    void Update()
    {
        Timer += Time.deltaTime;
    }

    private void OnDestroy() 
    {
        saveScore();
    }

    void saveScore()
    {
        PlayerPrefs.SetString(SCORE_KEY, Score.text);
        PlayerPrefs.Save();
        Debug.Log("Score Saved:" + Score.text);
    }
}
