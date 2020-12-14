using System;
using System.Globalization;

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
            var timeB = DateTime.ParseExact(dateB, "dd'/'MM'/'yyyy", new CultureInfo("es-CO"));
            return _dateTime.CompareTo(timeB);
        }

        public void SetTime(string date)
        {
            _dateTime = DateTime.ParseExact(date, "dd'/'MM'/'yyyy",  new CultureInfo("es-CO"));
        }

        public string GetTime()
        {
            return _dateTime.ToString("dd'/'MM'/'yyyy");
        }
    }
}