using System;

namespace StarDriver.domain.core.Contracts
{
    public class MyDate: IDates
    {
        private DateTime _dateTime;
        
        public MyDate(string date = "01/01/97")
        {
            SetTime(date);
        }

        public void SetTime(string date)
        {
            _dateTime = Convert.ToDateTime(date);
        }

        public string GetTime()
        {
           return _dateTime.ToLongDateString();
        }
    }
}