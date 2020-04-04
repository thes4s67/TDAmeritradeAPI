using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDAmeritradeAPI.Client;
using TDAmeritradeAPI.WebExample.Data.IRepository;

namespace TDAmeritradeAPI.WebExample.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Endpoint : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public Endpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("quote/{symbol}")]
        public IActionResult GetQuote(string symbol)
        {
            try
            {
                var accessToken = _unitOfWork.AccessToken.GetFirstOrDefault(c => c.Id == 1).access_token;
                var client = new TDClient(accessToken);
                var data = client.GetQuote(symbol).Result.Data;
                return Json(new
                {
                    success = true,
                    quote = data
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    success = false
                });
            }
        }
    }
}