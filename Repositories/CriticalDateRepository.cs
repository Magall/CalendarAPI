using System;
using System.Collections.Generic;
using System.Linq;
using Calendar.Data;
using Calendar.Models;
using Calendar.Models.Dtos;
using Calendar.Repositories.IRepository;
using SqlKata;
using SqlKata.Execution;

namespace Calendar.Repositories
{
    public class CriticalDateRepository : ICriticalDateRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly QueryFactory _Kata;
        public CriticalDateRepository(ApplicationDBContext db, QueryFactory Kata)
        {
            _db = db;
            _Kata = Kata;
        }

        public bool CreateCriticalDate(CriticalDate date)
        {
            _db.CriticalDates.Add(date);
            return Save();
        }

        public CriticalDate GetCriticalDate(int id)
        {
            return _db.CriticalDates.FirstOrDefault(dep => dep.Id == id);
        }

        public bool DeleteCriticalDate(CriticalDate date)
        {
            _db.CriticalDates.Remove(date);
            return Save();
        }

        public IEnumerable<CriticalDate> GetCriticalDates()
        {
            return _Kata.Query("CriticalDates")
                             .Select("*")
                             .Get<CriticalDate>();
        }

        public IEnumerable<CriticalDate> GetPeriodCriticalDates(DateTime begin, DateTime end)
        {
            return _Kata.Query("CriticalDates")
                            .Select("*")

                            .Get<CriticalDate>();

        }

        public bool Save()
        {
            try
            {
                return _db.SaveChanges() >= 0 ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}