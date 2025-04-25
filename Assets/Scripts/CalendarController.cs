using UnityEngine;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Systems.DateTime;
using Mono.Cecil.Cil;
using System;

public class CalendarController : MonoBehaviour
{
    public List<CalendarPanel> calendarPanels;
    public List<KeyDates> keyDates;
    public TextMeshProUGUI seasonText;
    public TextMeshProUGUI setDescription;
    public static TextMeshProUGUI DescriptionText;

    private int currentSeasonView = 0;
    private Systems.DateTime.DateTime previousDateTime;
    
    private void Awake()
    {
        TimeManager.OnDateTimeChanged += DateTimeChanged;
    }

    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= DateTimeChanged;
    }
    void Start()
    {
        DescriptionText = setDescription;
        DescriptionText.text = "";
        previousDateTime = TimeManager.DateTime;
        FillPanels((Season)0);

    }


    void DateTimeChanged(Systems.DateTime.DateTime _date)
    {
        if (currentSeasonView == (int)_date.SeasonType)
        {
            if(previousDateTime.Date != _date.Date)
            {
                var index = (previousDateTime.Date - 1) < 0 ? 0 : (previousDateTime.Date - 1);
                
            }
        }
    }

    private void FillPanels(Season _season)
    {
        seasonText.text = _season.ToString();

        for(int i = 0; i < calendarPanels.Count; i++)
        {
            calendarPanels[i].SetUpDate((i + 1).ToString());

            if(currentSeasonView == (int) TimeManager.DateTime.SeasonType && (i + 1) == TimeManager.DateTime.Date)
            {
                calendarPanels[i].ShowHighlight();
            }
            else
            {
                calendarPanels[i].HideHighlight();
            }

            foreach(var date in keyDates)
            {
                if ((i + 1) == date.KeyDate.Date && date.KeyDate.SeasonType == _season)
                {
                    calendarPanels[i].AssignKeyDate(date);
                }
            }
        }
    }

    public void OnNextSeason()
    {
        currentSeasonView += 1;
        if (currentSeasonView > 3) currentSeasonView = 0;
        FillPanels((Season)currentSeasonView);
    }

    public void OnPreviousSeason()
    {
        currentSeasonView -= 1;
        if (currentSeasonView < 0) currentSeasonView = 3;
        FillPanels((Season)currentSeasonView);
    }






}
