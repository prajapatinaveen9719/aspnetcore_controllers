using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_controllers.Controllers
{
    public class BankController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }


        public JsonResult AccountDetails()
        {
            var BankDetails = new[] {
           new{ Id=1, name="Naveen", BankAccount="01235" },
            new{ Id=2, name="Mansi", BankAccount="1456" }

        };
            return Json(BankDetails);
        }

        [Route("Bank/GetBalancebyAccountNo/{accountNo:int}")]
        public ActionResult GetBalancebyAccountNo(string accountNo)
        {
            var BankDetails = new[] {
           new{ Id=1, name="Naveen", BankAccount="01235",Balance=252 },
            new{ Id=2, name="Mansi", BankAccount="1456" ,Balance=500 }

        };

            var accountBalance = from x in BankDetails
                                 where
                                x.BankAccount== accountNo
                                 select  new { x.Balance } ;
            
           var balance= accountBalance.FirstOrDefault();
            if (balance==null)
            {
                return BadRequest("INVALID ACCOUNT NO");
            }


            return Json(balance);
        }

       


    }
}
