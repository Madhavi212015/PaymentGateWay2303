using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaymentGateWay.Models;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace PaymentGateWay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string makePayment(string accName, string account, string bsb, string amount)
        {
            //Make the payment by using payment gateway like _stripePaymentService
            try
            {
                PaymentModel pm = new PaymentModel();
                pm.AccName = accName;
                pm.Account = double.Parse(account);
                pm.Amount = int.Parse(amount);
                pm.ReceiptNum = "23031855555";

                string filePath = @"c:/Payment_" + accName;
                string fileName = account + DateTime.Now.ToFileTime().ToString().Replace("/", "");
                WriteToXmlFile(filePath, fileName, pm, true);
                return pm.ReceiptNum.ToString();
            }
            catch (Exception ex) { Console.Write(ex.ToString()); return "Failed"; }
        }
        public static void WriteToXmlFile(string filePath, string filename, PaymentModel objectToWrite, bool append = false)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer writer =
              new System.Xml.Serialization.XmlSerializer(typeof(PaymentModel));

                var path = filePath + "/" + filename + ".xml";
                System.IO.Directory.CreateDirectory(filePath);

                System.IO.FileStream file = System.IO.File.Create(path);

                writer.Serialize(file, objectToWrite);
                file.Close();
            }
            catch (Exception ex) { Console.Write(ex.ToString()); }
        }

    }
}