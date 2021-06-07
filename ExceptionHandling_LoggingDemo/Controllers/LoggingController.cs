using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExceptionHandling_LoggingDemo.Models;
using System.IO;

namespace ExceptionHandling_LoggingDemo.Controllers
{
    public class LoggingController : Controller
    {
        private readonly ILogger<LoggingController> _logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }


        // FOR CATEGORY 
        //private readonly ILogger _logger;

        ////public LoggingController(ILogger<LoggingController> logger)
        ////{
        ////    _logger = logger;
        ////}

        //public LoggingController(ILoggerFactory logger)
        //{
        //    _logger = logger.CreateLogger("MyCategory");
        //}
        public IActionResult Index()

        {
            _logger.LogTrace("Its a trace message");
            _logger.LogDebug("Its a debug message");
            _logger.LogInformation("Its an information");
            _logger.LogWarning("Its a warning");
            _logger.LogError("Its an error");
            _logger.LogCritical("Its a critical message");
            _logger.LogError("The server went down temprarily at {Time}", DateTime.UtcNow);

            try
            {
                throw new Exception("FOrgot to cathcj");
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex, "Tere was some error at {Time} ", DateTime.UtcNow);
            }
            return View();

        }

    }
}
