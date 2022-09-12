using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace InventoryManagerment.Common
{
    public static class Functions
    {
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        public static string CreateCode(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        public static string RemoveCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i]) >= '0' && str[i] <= '9')
                {
                    sb.Append(str[i]);
                }
            }
            return sb.ToString();
        }
        public static string NumberToMoney(string input)
        {
            if (input != "0")
            {
                if (!input.StartsWith("-"))
                {
                    string getStrNumb = "";
                    foreach (char kt in input) if (char.IsDigit(kt)) getStrNumb += kt;
                    return ((getStrNumb.Length > 0) ? (string.Format("{0:0,000}", decimal.Parse(getStrNumb))).Replace(',', ',') : "0");
                }
                else
                {
                    string getStrNumb = "";
                    foreach (char kt in input) if (char.IsDigit(kt)) getStrNumb += kt;
                    return "-" + ((getStrNumb.Length > 0) ? (string.Format("{0:0,000}", decimal.Parse(getStrNumb))).Replace(',', ',') : "0");
                }
            }
            else
            {
                return "0";
            }
        }
    }
}