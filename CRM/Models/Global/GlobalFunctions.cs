using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRM.Models.Global
{
    public class GlobalFunctions
    {
        public static void SetCookie(string key, string value)
        {
            TimeSpan expires = TimeSpan.FromDays(30);
            //HttpCookie encodedCookie = HttpSecureCookie.Encode(new HttpCookie(key, value));
            HttpCookie encodedCookie = new HttpCookie(key, value);
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var cookieOld = HttpContext.Current.Request.Cookies[key];
                cookieOld.Expires = DateTime.Now.Add(expires);
                cookieOld.Value = encodedCookie.Value;
                HttpContext.Current.Response.Cookies.Add(cookieOld);
            }
            else
            {
                encodedCookie.Expires = DateTime.Now.Add(expires);
                HttpContext.Current.Response.Cookies.Add(encodedCookie);
            }
        }
        public static string GetCookie(string key)
        {
            try
            {
                string value = string.Empty;
                HttpCookie cookie = HttpContext.Current.Request.Cookies[key];

                if (cookie != null)
                {
                    // For security purpose, we need to encrypt the value.
                    //HttpCookie decodedCookie = HttpSecureCookie.Decode(cookie);
                    HttpCookie decodedCookie = cookie;
                    value = decodedCookie.Value;

                }
                return value;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static void ExpireAllCookies()
        {
            if (HttpContext.Current != null)
            {
                int cookieCount = HttpContext.Current.Request.Cookies.Count;
                for (var i = 0; i < cookieCount; i++)
                {
                    var cookie = HttpContext.Current.Request.Cookies[i];
                    if (cookie != null)
                    {
                        var expiredCookie = new HttpCookie(cookie.Name)
                        {
                            Expires = DateTime.Now.AddDays(-1),
                            Domain = cookie.Domain
                        };
                        HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                    }
                }

                // clear cookies server side
                HttpContext.Current.Request.Cookies.Clear();
            }
        }
        public static void SetUsersCookies(DataTable dt)
        {
            SetCookie("ID", Convert.ToString(dt.Rows[0]["Id"]));
            SetCookie("UserId", Convert.ToString(dt.Rows[0]["UserID"]));
            SetCookie("FullName", Convert.ToString(dt.Rows[0]["FullName"]));
            SetCookie("EmailID", Convert.ToString(dt.Rows[0]["EmailID"]));
        }
        public static string GetFullName()
        {
            return Convert.ToString(GlobalFunctions.GetCookie("FirstName") + " " + GlobalFunctions.GetCookie("LastName")).ToLower();
        }
        public static List<T> ConverDataTableToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                return objT;
            }).ToList();
        }
        public static int GetUserId()
        {
            try
            {
                if (string.IsNullOrEmpty(GlobalFunctions.GetCookie("ID")))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(GlobalFunctions.GetCookie("ID"));
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public static int GetRoleId()
        {
            try
            {
                if (string.IsNullOrEmpty(GlobalFunctions.GetCookie("RoleId")))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(GlobalFunctions.GetCookie("RoleId"));
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int GetRandomNo()
        {
            Random r = new Random();
            int randNum = r.Next(1000000);
            int sixDigitNumber = Convert.ToInt32(randNum.ToString("D6"));
            return sixDigitNumber;
        }
        public static string GetLoginWithGmail()
        {
            return Convert.ToString(GlobalFunctions.GetCookie("LoginWithGmail")).ToLower();
        }
        public static string GetIsAgreementAccept()
        {
            return Convert.ToString(GlobalFunctions.GetCookie("IsAgreementAccept")).ToLower();
        }
        
    }
}