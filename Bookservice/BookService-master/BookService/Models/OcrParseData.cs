using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Models
{
    public class OcrParseData
    {
        public string Erf { get; set; }
        public string Suburb { get; set; }
        public string Address { get; set;}
        public string PurchasePrice { get; set; }

        public string Deposit { get; set; }
        public string LoanAmount { get; set; }
    }
}
