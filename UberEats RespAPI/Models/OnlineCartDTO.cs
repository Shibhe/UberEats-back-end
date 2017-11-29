using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UberEats_RespAPI.Models
{
    public class OnlineCartDTO
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int CustID { get; set; }
        public decimal TotAmt { get; set; }
        public int Quality { get; set; }
        public int RestID { get; set; }
        public string address { get; set; }
        public bool status { get; set; }
    }
}