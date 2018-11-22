using Microsoft.AspNetCore.Mvc;
using Support.Models;
using Support.Persistence;
using Support.Repository;

namespace Support.Controllers
{
    [Route("api/[controller]/[action]")]
    
    public class ValueController :ControllerBase
    {
        private readonly UhcContext context;
        [HttpPost]
        public IActionResult GetPaymentsAsync( string searchString = "")
        {
            Repo repo = new Repo();
            var ListOfPeople = repo.GetAllPaymentsAsync(searchString);
            return Ok(ListOfPeople);
        }
        [HttpPost]
        public IActionResult AddAgent([FromBody]AppUsers appUsers)
        {
            Repo repo = new Repo();
            repo.InsertAgent(appUsers);
            return Ok();
        }
        [HttpPost]
        public IActionResult EditPayments([FromBody]PaymentViewModel payments)
        {
            Repo repo = new Repo();
            repo.UpdatePayments(payments);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddPayment([FromBody]PaymentViewModel payments)
        {
            Repo repo = new Repo();
            repo.CreatePayment(payments);
            return Ok();
        }
    }
}