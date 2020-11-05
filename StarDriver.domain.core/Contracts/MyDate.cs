using System;

namespace StarDriver.domain.core.Contracts
{
    public class MyDate: IDates
    {
        private DateTime _dateTime;
        
        public MyDate(string date = "01/01/1998")
        {
            SetTime(date);
        }

        public int CompareTo(string dateB)
        {
            var timeB = Convert.ToDateTime(dateB);
            return _dateTime.CompareTo(timeB);
        }

        public void SetTime(string date)
        {
            _dateTime = Convert.ToDateTime(date);
        }

        public string GetTime()
        {
            return _dateTime.ToString("MM'/'dd'/'yyyy");
        }
    }
}