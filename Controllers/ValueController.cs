using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Support.Models;
using Support.Persistence;
using Support.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
namespace Support.Controllers
{
    
    [Route("api/[controller]/[action]")]
    
    public class ValueController :ControllerBase
    {
        private readonly UhcContext context;
        [HttpPost]
        public async Task<IActionResult> GetPaymentsAsync([FromBody]PaginationArg arg)
        {
            
            Repo repo = new Repo();
            var ListOfPeople = await repo.GetAllPaymentsAsync(arg);
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
        [HttpPost]
        public async Task<IActionResult> UploadBulkFile([FromForm]File NewFile)
        {
            Repo repo = new Repo();
            PaymentModel payments = new PaymentModel();
            if (NewFile.file == null || NewFile.file.Length == 0)
            {
                return RedirectToAction(actionName: nameof(BulkPayment));
            }
            using (var memoryStream = new MemoryStream())
            {
                await NewFile.file.CopyToAsync(memoryStream).ConfigureAwait(false);

                using (var package = new ExcelPackage(memoryStream))
                {
                    var worksheet = package.Workbook.Worksheets[NewFile.WorkSheet];

                    payments = repo.readExcelPackageToStringBulk(package, worksheet, NewFile.date);
                    // Tip: To access the first worksheet, try index 1, not 0

                }
            }

            return Ok(payments);
        }

    }
    public class SearchStr
    {
          public string SearchValue { get; set; }  
    }
    public class File
    {
        public IFormFile file { get; set; }
        public DateTime date { get; set; }
        public int WorkSheet { get; set; }
             
    }
}