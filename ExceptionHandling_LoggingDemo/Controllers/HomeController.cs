using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExceptionHandling_LoggingDemo.Models;
using System.IO;
using Microsoft.AspNetCore.Diagnostics;

namespace ExceptionHandling_LoggingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)

        {
            if (id.HasValue)
            {
                if (id == 0)
                {

                    int x = 10;
                    int? res = x / id;
                    throw new DivideByZeroException();
                }
                if (id == 1)
                    throw new FileNotFoundException("File not found exception thrown in index.chtml");
                else if (id == 2)
                {
                    return StatusCode(500);
                }
            }
            return View();
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        public IActionResult Failing()
        {
            throw new Exception("Testing custom exception filter.");
        }
        public IActionResult MyStatusCode(int code)
        {
            if (code == 404)
            {
                ViewBag.ErrorMessage = "The requested page not found.";
            }
            else if (code == 500)
            {
                ViewBag.ErrorMessage = "My custom 500 error message.";
            }
            else
            {
                ViewBag.ErrorMessage = "An error occurred while processing your request.";
            }

            ViewBag.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ViewBag.ShowRequestId = !string.IsNullOrEmpty(ViewBag.RequestId);
            ViewBag.ErrorStatusCode = code;

            return View();
        }




       	public IActionResult MyStatusCode2(int code)
 	{  
 	    var statusCodeReExecuteFeature = HttpContext.Features.Get <IStatusCodeReExecuteFeature> ();  
 	    if (statusCodeReExecuteFeature != null)  
 	    {  
 	        ViewBag.OriginalURL =  
 	            statusCodeReExecuteFeature.OriginalPathBase  
 	            + statusCodeReExecuteFeature.OriginalPath  
 	            + statusCodeReExecuteFeature.OriginalQueryString;  
 	    }  
     ViewBag.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;  
 	    ViewBag.ShowRequestId = !string.IsNullOrEmpty(ViewBag.RequestId);  
 	    ViewBag.ShowOriginalURL = !string.IsNullOrEmpty(ViewBag.OriginalURL);  
 	    ViewBag.ErrorStatusCode = code;  
 	  
 	    return View();  
 	} 



    }
}
