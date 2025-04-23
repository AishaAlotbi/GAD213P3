using UnityEngine;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using System;
using Systems.DateTime;
using Mono.Cecil.Cil;

public class CalendarController : MonoBehaviour
{
    public List<CalendarPanel> calendarPanels;
    public List<KeyDates> keyDates;
    public TextMeshProUGUI seasonText;
    public TextMeshProUGUI setDescription;
    public static TextMeshProUGUI DescriptionText;

    private int currentSeasonView = 0;
    private DateTime previousDateTime;
    
    private void Awake()
    {
       // TimeManager.OnDateTimeChanged += DateTimeChanged;
    }

    private void OnDisable()
    {
        //TimeManager.OnDateTimeChanged -= DateTimeChanged;
    }
    void Start()
    {
        DescriptionText = setDescription;
        DescriptionText.text = "";
     //   previousDateTime = TimeManager.DateTime;
        SortDates();
      //  FillPanels((Season)0);

    }

   /* void DateTimeChanged(DateTime _date)
    {
        if (currentSeasonView == (int)_date.Season)
        {
            if(previousDateTime.Date != _date.Date)
            {
                var index = (previousDateTime.Date - 1) < 0 ? 0 : (previousDateTime.Date - 1);
                
            }
        }
    }
   */

    private void SortDates()
    {

    }
    

   
}
