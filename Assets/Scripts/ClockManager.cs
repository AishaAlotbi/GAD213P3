using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;



public class ClockManager : MonoBehaviour
{
   
    public TextMeshProUGUI Date, Time, Week;

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

        float t = (float)dateTime.Hour/ 24f;

    }
}
