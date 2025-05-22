using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controller
{
    public class Error : ControllerBase
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult HandleError()
        {
            return Problem();
        }
    }
}