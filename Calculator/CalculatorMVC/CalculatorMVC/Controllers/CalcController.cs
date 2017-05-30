using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorMVC.Controllers
{
    public class CalcController:Controller
    {

       
        public ActionResult MM()
        {
            return View();
        }
    }
}
