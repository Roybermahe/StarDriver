using System;

namespace StarDriver.domain.core.Contracts
{
    public class MyDate: IDates
    {
        private readonly DateTime _dateTime;

        public MyDate(string date)
        {
            _dateTime = Convert.ToDateTime(date);
        }
        
        /*public string GetDay()
        {
            return _dateTime.Day.ToString("dd");
        }

        public string GetYear()
        {
            return _dateTime.Year.ToString("yyyy");
        }

        public string GetMonth()
        {
            return _dateTime.Month.ToString("MM");
        }

        public string GetHours()
        {
            return _dateTime.Hour.ToString("HH");
        }*/
    }
}