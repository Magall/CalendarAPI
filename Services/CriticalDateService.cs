using System;
using System.Collections.Generic;
using Calendar.Models;
using Calendar.Repositories.IRepository;
using Calendar.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Services
{
    public class CriticalDateService : ICriticalDateService
    {
        private readonly ICriticalDateRepository _dateRepo;

        public CriticalDateService(ICriticalDateRepository dateRepo)
        {
            _dateRepo = dateRepo;
        }
        public ObjectResult CreateCriticalDate(CriticalDate date)
        {
             DateTime today = DateTime.Today;
            // Validação para uma data nunca começar antes do dia de inserção e a data de fim sempre ser posterior a de início
            if (date.Begin > date.End  || date.Begin < today)
            {
                return new ObjectResult("Erro , verifique se as datas inseridas são posteriores ao dia de hoje e se a data final é posterior a inicial. ") { StatusCode = 500 };
            }
            else
            {

                if (_dateRepo.CreateCriticalDate(date))
                {
                   return new ObjectResult("Registro inserido") { StatusCode = 200 };
                }
                else
                {
                    return new ObjectResult("Erro ao inserir o Registro.") { StatusCode = 500 };
                    
                }
            }
        }

        public ObjectResult DeleteCriticalDate(int id)
        {
            var date = _dateRepo.GetCriticalDate(id);
            if(date is null){
                return new ObjectResult("Data crítica não encontrada") { StatusCode =  404 };
            }
            else{
                if(_dateRepo.DeleteCriticalDate(date)){
                    return new ObjectResult("Data crítica removida com sucesso"){StatusCode = 204};
                }
                else{
                    return new ObjectResult("Erro ao remover a data crítica "){StatusCode = 500};
                }
            }
        }

        public IEnumerable<CriticalDate> GetMonthDates()
        {
            DateTime today = DateTime.Today;
            DateTime endDate = today.AddDays(30);
            var dcs = _dateRepo.GetPeriodCriticalDates(today, endDate);
            return dcs;
        }
    }
}