using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Calculate(Results result)
        {
           /*choose the sign and set the result.result*/
            switch (result.sing)
            {
                case "+":
                    result.result = double.Parse(result.val1) + double.Parse(result.val2);
                    break;
                case "-":
                    result.result = double.Parse(result.val1) - double.Parse(result.val2);
                    break;
                case "*":
                    result.result = double.Parse(result.val1) * double.Parse(result.val2);
                    break;
                case "/":
                    result.result = double.Parse(result.val1) / double.Parse(result.val2);
                    break;
                case "Sqr":
                    result.val2 = null;
                    result.result = Math.Sqrt(double.Parse(result.val1));
                    break;
                case "x*x":
                    result.val2 = null;
                    result.result = double.Parse(result.val1) * double.Parse(result.val1);
                    break;
                default:
                    result.result = 0.0;
                    break;
            }
            /*
             * Call SaveProcess method
             * If data Saved return the view
             * If data not save return Content with message show that that data not saved
             */
            if (SaveProcess(result)){
                return View(result);
            }
            else
            {
                return Content("failed to save in database");
            }
            
        }

        /*
         * SaveProcess Method , the Create connection with the database
         * and saving data.
         */
        public bool SaveProcess(Results result)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand query = new SqlCommand(String.Format("insert into Results values('{0}','{1}','{2}','{3}')", result.val1, result.val2, result.sing, result.result), conn);
                query.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
    }
}