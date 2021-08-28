using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public double x;
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult Calculat(string val1, string val2,string sign)
        {
            /*check if the entry in null */
            if (String.IsNullOrWhiteSpace(val1))
            {
                return RedirectToAction("Index","Home") ;
            }
            /* if the val1 is not null*/
            else
            {
                /*Open Databae Connection*/
                string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                
                //if the val2 was null then will return an erro. but we need to Sqr
                try
                {
                    if (sign.Equals("+"))
                    {
                        ViewBag.Message = String.Format("{0} {2} {1} = {3}", val1, val2, sign, (double.Parse(val1) + double.Parse(val2)).ToString());
                    }
                    else if (sign.Equals("-"))
                    {
                        ViewBag.Message = String.Format("{0} {2} {1} = {3}", val1, val2, sign, (double.Parse(val1) - double.Parse(val2)).ToString());
                    }
                    else if (sign.Equals("*"))
                    {
                        ViewBag.Message = String.Format("{0} {2} {1} = {3}", val1, val2, sign, (double.Parse(val1) * double.Parse(val2)).ToString());
                    }
                    else if (sign.Equals("/"))
                    {
                        ViewBag.Message = String.Format("{0} {2} {1} = {3}", val1, val2, sign, (double.Parse(val1) / double.Parse(val2)).ToString());
                    }
                    else if (sign.Equals("%"))
                    {
                        ViewBag.Message = String.Format("{0} {2} {1} = {3}", val1, val2, sign, (double.Parse(val1) % double.Parse(val2)).ToString());
                    }
                    else if (sign.Equals("Sql"))
                    {
                        ViewBag.Message = String.Format("{0} {2} {1} = {3}", val1, val2, sign, Math.Sqrt(double.Parse(val1)).ToString());
                    }
                    /*Open Connection and add values*/
                    conn.Open();
                    SqlCommand query = new SqlCommand(String.Format("insert into Results values ('{0}','{1}','{2}')",val1,val2,sign),conn);
                    query.ExecuteNonQuery();
                    conn.Close();
                    /*Close Connection*/

                    return View();
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Syntax Error";
                    return View();
                }
                

            }
           
        }

        
    }
}