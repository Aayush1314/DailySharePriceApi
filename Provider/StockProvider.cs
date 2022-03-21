using DailySharePriceApi.Model;
using DailySharePriceApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceApi.Provider
{
    public class StockProvider : IStockProvider
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(StockProvider));

        private readonly IStockRepository _stockrepository;

        public StockProvider(IStockRepository stockrepository)
        {
            _stockrepository = stockrepository;

        }
            /// It is a Method in Provider that is called by the Controller and returns the Stock by Name
    public StockPriceDetails GetStockByName(string stockname)
            {
            StockPriceDetails stockData = null;
                try
                {
                    _log4net.Info("In StockProvider, Controller has called GetStockByNameProvider and " + stockname + " is searched");
                    stockData = _stockrepository.GetStockByNameRepository(stockname);
                }
                catch (Exception ex)
                {
                    _log4net.Error("In StockProvider, Exception is Found - " + ex.Message);
                }
                return stockData;
            }

        }
    }
