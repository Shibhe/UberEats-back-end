using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UberEats_RespAPI.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string itemName { get; set; }
        public double itemPrice { get; set; }
        public string description { get; set; }
        public string itemType { get; set; }
        public int userID { get; set; }
        public string itemImage { get; set; }
    }
}