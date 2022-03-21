using DailySharePriceApi.Model;
using DailySharePriceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceApi.Repository
{
    public interface IStockRepository
    {
        public StockPriceDetails GetStockByNameRepository(string stockname);
    }
}