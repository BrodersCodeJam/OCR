using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using OCRParse;

namespace OcrParseTests
{
    [TestClass]
    public class OcrParseTests
    {

        public string TextToParse { get; set; }
        public OCRParser OcrParser { get; set; }

        [TestInitialize]
        public void Setup()
        {



            TextToParse = File.ReadAllText(@"../../Standard OTP.txt");
            OcrParser = new OCRParser();

            //var result = ocrParser.GetPropertyInfo(text);
        }


        [TestMethod]
        public void GetPropertyInfo()
        {


            var result = OcrParser.GetPropertyInfo(TextToParse);
            
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result["erf"] == "1145");
            Assert.IsTrue(result["area"].ToLower() == "fairlands".ToLower());
            Assert.IsTrue(result["address"].ToLower() == "69 Kessel Street".ToLower());


        }


        [TestMethod]
        public void GetMoneyInfo()
        {

            var result = OcrParser.GetPriceInfo(TextToParse);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result["purchaseprice"] == "1 300 000");
            Assert.IsTrue(result["depositamount"].ToLower() == "1 000 000".ToLower());
            Assert.IsTrue(result["loanamount"].ToLower() == "300 000".ToLower());
        }

        [TestMethod]
        public void GetCustomerInfo()
        {

            var result = OcrParser.GetCustomerInfo(TextToParse);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result["fullname"].ToLower() == "".ToLower());
          
            Assert.IsTrue(result["idnumber"].ToLower() == "1 000 000".ToLower());
            Assert.IsTrue(result["dateofbirth"].ToLower() == "1 000 000".ToLower());
            Assert.IsTrue(result["address"].ToLower() == "1 000 000".ToLower());
            
        }
    }
}
