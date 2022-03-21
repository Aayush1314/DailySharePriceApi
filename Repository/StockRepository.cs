using DailySharePriceApi.Model;
using DailySharePriceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DailySharePriceApi.Repository
{
    [ExcludeFromCodeCoverage]
    public class stockRepository : IStockRepository
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(stockRepository));
   private readonly PortfolioContext _portfolioContext;
        public stockRepository(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }




        /// <summary>
        /// It is a Method in Repository that is being called by the Provider and returns the Stock based on the StockName
        /// </summary>
        /// <param name="stockname"></param>
        /// <returns></returns>


        public StockPriceDetails GetStockByNameRepository(string stockname)
        {
            StockPriceDetails stockData = null;
            try
            {
                _log4net.Info("In Stock Repository, StockProvider is calling the Method GetStockByNameRepository and " + stockname + " is being searched");
                stockData = _portfolioContext.StockPriceDetails.Where(s => s.StockName == stockname).FirstOrDefault();

                if (stockData != null)
                {
                    var jsonStock = JsonConvert.SerializeObject(stockData);
                    _log4net.Info("Stock Found " + jsonStock);
                }
                else
                {
                    _log4net.Info("In StockRepository, Stock " + stockname + " is not found");
                }
            }
            catch (Exception ex)
            {
                _log4net.Error("In Stock Repository, Exception Found - " + ex.Message);
            }
            return stockData;
        }

    }
}

