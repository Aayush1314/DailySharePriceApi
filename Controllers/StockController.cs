using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using DailySharePriceApi.Model;
using DailySharePriceApi.Models;
using DailySharePriceApi.Provider;
using DailySharePriceApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailySharePriceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(StockController));

        private readonly IStockProvider _stockprovider;

        public StockController(IStockProvider stockprovider)
        {
            _stockprovider = stockprovider;
        }
       
        /// Returning the Stock with the name equal to the one in parameter
        
        [HttpGet("{stockname}")]
        public IActionResult GetStockByName(string stockname)
        {
            try
            {
                _log4net.Info("In StockController, HttpGet GetStockByName and " + stockname + " is searched");
                if (string.IsNullOrEmpty(stockname))
                {
                    _log4net.Info("StockController Null Name");
                    return BadRequest("Null or Empty Name is passed");
                }
                else
                {
                    StockPriceDetails result = _stockprovider.GetStockByName(stockname.ToUpper());
                    if (result == null)
                    {
                        _log4net.Info("StockController Stock " + stockname + " Not Found");
                        return NotFound(stockname + " Stock Not Found");
                    }
                    else
                    {
                        _log4net.Info("Stock Found");
                        return Ok(result);
                    }
                }
            }
            catch (Exception ex)
            {
                _log4net.Error("Stock Controller Exception Found - " + ex.Message);
                return new StatusCodeResult(500);
            }
        }

    }
    }

