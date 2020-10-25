using System;
using System.Collections;
using System.Collections.Generic;
using Calendar.Models;
using Calendar.Models.Dtos;

namespace Calendar.Repositories.IRepository
{
    public interface ICriticalDateRepository
    {
        IEnumerable<CriticalDate> GetCriticalDates();
        IEnumerable<CriticalDate> GetPeriodCriticalDates(DateTime begin , DateTime end); 
        
        bool CreateCriticalDate(CriticalDate date);
        bool DeleteCriticalDate(CriticalDate date);
        CriticalDate GetCriticalDate(int id);
        bool Save();
    }
}