using System;

namespace StarDriver.domain.core.Contracts
{
    public interface IDates
    {
        int CompareTo(string dateB);
        // string GetDay();
        // string GetYear();
        // string GetMonth();
        // string GetHours();
        void SetTime(string date);
        string GetTime();
    }
}