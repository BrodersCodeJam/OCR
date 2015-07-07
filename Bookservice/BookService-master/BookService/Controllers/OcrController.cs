using BookService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace BookService.Controllers
{
    public class OcrController : ApiController
    {

        // GET: api/Books/5
        [ResponseType(typeof(OcrParseData))]
        public async Task<IHttpActionResult> GetOcrData()
        {
            OcrParseData parsedData = new OcrParseData();
            var text = OcredDataFromABBYY.RealOcredData;

           OCRParser parser = new OCRParser();
           var propInfo = parser.GetPropertyInfo(text);
           var custinfo = parser.GetCustomerInfo(text);
           var priceinfo = parser.GetPriceInfo(text);



           parsedData.Address = propInfo["address"];
           parsedData.Deposit = priceinfo["depositamount"];
           parsedData.Erf = propInfo["erf"];
           parsedData.LoanAmount = priceinfo["loanamount"];
           parsedData.PurchasePrice = priceinfo["purchaseprice"];
           parsedData.Suburb = propInfo["area"];

            
            return Ok(parsedData);
        }


    }
}
