using System;
using UnityEngine;
using UnityEngine.Events;

namespace Systems.DateTime
{


    public class TimeManager : MonoBehaviour
    {
        [Header("Date & Time Settings")]
        [Range(1, 28)]
        public int dateInMonth;
        [Range(1, 4)]
        public int season;
        [Range(1, 99)]
        public int year;
        [Range(0, 24)]
        public int hour;
        [Range(0, 6)]
        public int minutes;

        private DateTime dateTime;

        [Header("Tick Settings")]
        public int tickMinutesIncrease = 10;
        public float timeBetweenTicks = 1;
        private float currentTimeBetweenTicks = 0;

        public static UnityAction<DateTime> OnDateTimeChanged; //RE

        private void Awake()
        {
            dateTime = new DateTime(dateInMonth, season - 1, year, hour, minutes * 10);

        }

        private void Start()
        {
            OnDateTimeChanged?.Invoke(dateTime);
        }

        private void Update()
        {
            currentTimeBetweenTicks += Time.deltaTime;
            if (currentTimeBetweenTicks >= timeBetweenTicks)
            {
                currentTimeBetweenTicks = 0;
                Tick();
            }
        }

        void Tick()
        {
            AdvanceTime();
        }

        void AdvanceTime()
        {
            dateTime.AdvanceMinutes(tickMinutesIncrease);
            OnDateTimeChanged?.Invoke(dateTime);
        }

        [System.Serializable]

        public struct DateTime
        {
            #region Feilds

            private Days day;
            [SerializeField] private int date;
            [SerializeField] private int year;

            [SerializeField] private int hour;
            [SerializeField] private int minutes;

            [SerializeField] private Season season;

            private int totalNumDays;
            private int totalNumWeeks;

            #endregion

            #region Properties

            public Days Day => day;
            public int Date => date;
            public int Hour => hour;
            public int Minute => minutes;
            public Season SeasonType => season;
            public int yYear => year;
            public int TotalNumDays => totalNumDays;
            public int TotalNumWeeks => totalNumWeeks;
            public int CurrentWeek => totalNumWeeks % 16 == 0 ? 16 : totalNumWeeks % 16;

            #endregion

            #region Constructors

            public DateTime(int date, int season, int year, int hour, int minutes)
            {
                // this.date = (int)(Days)(date % 7);
                // if (day == 0) day = (Days)7;
                this.date = date == 0 ? 1 : date;
                this.day = (Days)((this.date - 1) % 7 + 1);


                this.date = date;
                this.season = (Season)season;
                this.year = year;
                this.hour = hour;
                this.minutes = minutes;

                //totalNumDays = this.date + 112 * (this.year - 1);
                // totalNumWeeks = 1 + totalNumDays / 7;
                totalNumDays = date + (28 * (int)this.season) + (122 * (year - 1));
                totalNumWeeks = 1 + totalNumDays / 7;
            }

            #endregion

            #region Time Advancement

            public void AdvanceMinutes(int secondsToAdvanceBy)
            {
                if (minutes + secondsToAdvanceBy >= 60)
                {
                    minutes = (minutes + secondsToAdvanceBy) % 60;
                    AdvanceHour();
                }
                else
                {
                    minutes += secondsToAdvanceBy;
                }
            }

            private void AdvanceHour()
            {
                if ((hour + 1) == 24)
                {
                    hour = 0;
                    AdvanceDay();
                }
                else
                {
                    hour++;
                }
            }

            private void AdvanceDay()
            {
                if (day + 1 > (Days)7)
                {
                    day = (Days)1;
                    totalNumWeeks++;
                }
                else
                {
                    day++;
                }

                if (date % 29 == 0)
                {
                    AdvanceSeason();
                    date = 1;
                }

                totalNumDays++;
            }

            private void AdvanceSeason()
            {
                if (season == Season.Winter)
                {
                    season = Season.Spring;
                    AdvanceYear();
                }

            }
            private void AdvanceYear()
            {
                date = 1;
                year++;
            }

            #endregion

            #region Bool Check

            public bool IsNight()
            {
                return hour >= 18 || hour < 6;
            }

            public bool IsMorning()
            {
                return hour >= 6 && hour <= 12;
            }

            public bool IsAfternoon()
            {
                return hour > 12 && hour < 18;
            }

            public bool IsWeekend()
            {
                return day > Days.Fri ? true : false;
            }

            public bool IsParticularDay(Days _day)
            {
                return day == _day;
            }
            #endregion


            #region To String
            public override string ToString()
            {
                return $"Date: {DateToString()} Season: {season.ToString()} Time: {TimeToString()} " + $"\nTotal Days: {totalNumDays} | Total Weeks: {totalNumWeeks}";
            }

            public string DateToString()
            {
                return $"{Day} {Date} {year.ToString("D2")}";
            }

            public string TimeToString()
            {
                int adjustedHour = 0;

                if (hour == 0)
                {
                    adjustedHour = 12;
                }
                else if (hour == 24)
                {
                    adjustedHour = 12;
                }
                else if (hour >= 13)
                {
                    adjustedHour = hour - 12;
                }
                else
                {
                    adjustedHour = hour;
                }

                string AmPm = hour == 0 || hour < 12 ? "AM" : "PM";
                return $"{adjustedHour.ToString("D2")}:{minutes.ToString("D2")}{AmPm}";
            }
            #endregion

            [System.Serializable]
            public enum Days
            {
                NULL = 0,
                Mon = 1,
                Tue = 2,
                Wed = 3,
                Thu = 4,
                Fri = 5,
                Sat = 6,
                Sun = 7,

            }

            [System.Serializable]
            public enum Season
            {
                Spring = 0,
                Summer = 1,
                Fall = 2,
                Winter = 3


            }
        }
    }
}

