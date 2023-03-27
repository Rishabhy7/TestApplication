using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult CountryMaster()
        {
            return View();
        }
        public JsonResult InsertUpdateCountryMaster(string CountryID, string CountryCode, string CountryName)
        {
            Dictionary<string,string> dic = new Dictionary<string,string>();
            dic["Message"] = "";
            try
            {
                string[,] Param = new string[,]
                {
                    {"@CountryID",CountryID },
                    {"@CountryCode",CountryCode },
                    {"@CountryName",CountryName }
                };
                DataTable dt = Common.ExecuteProcedure("USP_InsertUpdateCountry",Param);
                if(dt.Rows.Count > 0)
                {
                    dic["Message"] = dt.Rows[0]["Msg"].ToString();
                }
            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }
        public  JsonResult ShowCountryMaster()
        {
            StringBuilder sb= new StringBuilder();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            dic["Grid"] = "";
            try
            {
                DataTable dt = Common.ExecuteProcedure("USP_ShowCountryMaster");
                if(dt.Rows.Count > 0)
                {
                    sb.Append("<table border='1'><tr>");
                    sb.Append("<th>Edit</th>");
                    sb.Append("<th>Delete</th>");
                    sb.Append("<th>Country Code</th>");
                    sb.Append("<th>Country Name</th></tr>");
                    for(int i=0; i<dt.Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td><button type='button' onclick='EditCountryMaster(" + dt.Rows[i]["CountryID"].ToString() +")'>Edit</button>");
                        sb.Append("<td><button type='button' onclick='DeleteCountryMaster(" + dt.Rows[i]["CountryID"].ToString() + ")'>Delete</button>");
                        sb.Append("<td>" + dt.Rows[i]["CountryCode"].ToString() + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["CountryName"].ToString() + "</td></tr>");
                    }
                    sb.Append("</table>");
                    dic["Grid"] = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                dic["Message"]=ex.Message;
            }
            return Json(dic);
        }

        public JsonResult EditCountryMaster(string CountryID)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            dic["CountryCode"] = "";
            dic["Country"] = "";
            try
            {
                string[,] Param = new string[,]
                {
                    {"@CountryID",CountryID }
                };
                DataTable dt = Common.ExecuteProcedure("USP_ShowCountryMaster");
                if(dt.Rows.Count > 0)
                {
                    dic["CountryCode"] = dt.Rows[0]["CountryCode"].ToString();
                    dic["CountryName"] = dt.Rows[0]["CountryName"].ToString();
                }
            }
            catch (Exception ex) 
            {
                dic["Message"]=ex.Message;
            }
            return Json(dic);
        }
        public JsonResult DeleteCountryMaster(string CountryID)
        {
            Dictionary<string, string> dic =new Dictionary<string, string>();
            dic["Message"] = "";
            try
            {
                string[,] Param = new string[,]
                {
                    {"@CountryID", CountryID }
                };
                DataTable dt = Common.ExecuteProcedure("USP_DeleteCountryMaster", Param);
                if(dt.Rows.Count > 0)
                {
                    dic["Message"] = dt.Rows[0]["Msg"].ToString();
                }
            }
            catch (Exception ex)
            {
                dic["Message"]=ex.Message;
            }
            return Json(dic);
        }
    }
}