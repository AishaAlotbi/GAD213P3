using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Systems.DateTime;



public class ClockManager : MonoBehaviour
{
   
    public TextMeshProUGUI Date, Time, Season, Week;

    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += UpdateDateTime;
        
        /*if (TimeManager.Instance != null)
        {
            UpdateDateTime(TimeManager.Instance.GetCurrentDateTime());
        }
        else
        {
            Debug.LogWarning("TimeManager.Instance is null — will wait for event.");
        }

        */
    }
    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= UpdateDateTime;
    }

    private void UpdateDateTime(Systems.DateTime.DateTime dateTime)
    {
        Date.text = dateTime.DateToString();
        Time.text = dateTime.TimeToString();
        Week.text = $"WK: {dateTime.CurrentWeek}";
        Season.text = dateTime.SeasonType.ToString();

        float t = (float)dateTime.Hour/ 24f;

    }
}
