using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRParse
{
    public class OCRParser
    {
        /// <summary>
        /// I know this isnt full on capable OCR but in terms of mocking and actual use of a mocking service, this is the best we could do 
        /// </summary>
        /// <param name="parsetext"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetPropertyInfo(string parsetext)
        {

            Dictionary<string, string> results = new Dictionary<string, string>();

            results.Add("Erf".ToLower(), Substring(parsetext, "Erf", "Area").Trim());
            results.Add("Area".ToLower(), Substring(parsetext, "Area", "commonly known").Trim());
            results.Add("Address".ToLower(), Substring(parsetext, "known as", "l/We").Trim());
         
            
         
            return results;

        }

        public Dictionary<string, string> GetPriceInfo(string parsetext)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();

            results.Add("purchaseprice".ToLower(), Substring(parsetext, "The purchase price shall be R ", "payable as follows:").Trim());
            results.Add("depositamount".ToLower(), Substring(parsetext, "2.1.    R ", "within 30 days of").Trim());
            results.Add("loanamount".ToLower(), Substring(parsetext, " financial institution approving a loan to the Purchaser, for ", "on its standard terms and conditions").Trim());



            return results;
        }


        public Dictionary<string, string> GetCustomerInfo(string parsetext)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();


            string purchaser = Substring(parsetext, "PURCHASER", "SELLER");


            results.Add("fullname".ToLower(), Substring(purchaser, "Full Names ".Trim(), "I.D. Number").Trim());

            results.Add("idnumber".ToLower(), Substring(purchaser, "I.D. Number", "Date of Birth").Trim());
           // results.Add("incomenumber".ToLower(), Substring(parsetext, "2.1.    R ", "within 30 days of").Trim());
            results.Add("dateofbirth".ToLower(), Substring(purchaser, "Date of Birth", "Spouse’s").Trim());
            results.Add("address".ToLower(), Substring(purchaser, "Address ", "Telephone No.").Trim());




            return results;

        }





        private string Substring( string parseText, string from = null, string until = null, StringComparison comparison = StringComparison.InvariantCulture)
        {
            var fromLength = (from ?? string.Empty).Length;
            var startIndex = !string.IsNullOrEmpty(from)
                ? parseText.IndexOf(from, comparison) + fromLength
                : 0;

            if (startIndex < fromLength) { throw new ArgumentException("from: Failed to find an instance of the first anchor"); }

            var endIndex = !string.IsNullOrEmpty(until)
            ? parseText.IndexOf(until, startIndex, comparison)
            : parseText.Length;

            if (endIndex < 0) { throw new ArgumentException("until: Failed to find an instance of the last anchor"); }

            var subString = parseText.Substring(startIndex, endIndex - startIndex);
            return subString;
        }



        
    }
}
