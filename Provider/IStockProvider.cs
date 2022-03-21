using DailySharePriceApi.Model;
using DailySharePriceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceApi.Provider
{
    public interface IStockProvider
    {
        public StockPriceDetails GetStockByName(string stockname);
    }
}
