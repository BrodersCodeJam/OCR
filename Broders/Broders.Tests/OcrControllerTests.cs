using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using brodersService.Controllers;
using System.IO;
using System.Net.Http;
using System.Net;

namespace Broders.Tests
{
    [TestClass]
    public class OcrControllerTests
    {

        //OCRController ocrController {get;set;}

        //[TestInitialize]
        //public void Setup
        //{
        //    ocrController = new OCRController(); 
        //}


        [TestMethod]
        public void UploadFileToWebApi()
        {
            var ocrController = new OCRController();
            //var pdfToUpload = File.Open(@"../../Standard OTP.pdf", FileMode.Open);
            string baseurl = "http://localhost:50265/";


            var imageFile = @"../../Standard OTP.pdf";
            WebClient webClient = new WebClient();
            byte[] rawResponse = webClient.UploadFile(string.Format("{0}/api/ocr/", baseurl), imageFile);
            Console.WriteLine("Sever Response: {0}", System.Text.Encoding.ASCII.GetString(rawResponse)); // for debugging purposes
            Console.WriteLine("File Upload was successful");


        }
    }
}
