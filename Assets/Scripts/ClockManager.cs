using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Systems.DateTime;



public class ClockManager : MonoBehaviour
{
   
    public TextMeshProUGUI Date, Time, Season, Week;

    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += UpdateDateTime;
    }
    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= UpdateDateTime;
    }

    private void UpdateDateTime(TimeManager.DateTime dateTime)
    {
        Date.text = dateTime.DateToString();
        Time.text = dateTime.TimeToString();
        Week.text = $"WK: {dateTime.CurrentWeek}";
        Season.text = dateTime.SeasonType.ToString();

        float t = (float)dateTime.Hour/ 24f;

    }
}
