using System.Collections.Generic;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Services.IServices
{
    public interface ICriticalDateService
    {
         ObjectResult CreateCriticalDate(CriticalDate date);
         IEnumerable<CriticalDate> GetMonthDates();
         ObjectResult DeleteCriticalDate(int id);
    }
}