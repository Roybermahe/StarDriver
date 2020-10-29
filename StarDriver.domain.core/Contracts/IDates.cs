using System;

namespace StarDriver.domain.core.Contracts
{
    public interface IDates
    {
        // string GetDay();
        // string GetYear();
        // string GetMonth();
        // string GetHours();
        void SetTime(string date);
        string GetTime();
    }
}