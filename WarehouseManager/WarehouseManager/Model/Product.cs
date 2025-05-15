using Microsoft.Win32;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string image { get; set; }
        public string Description { get; set; }
        public int  StockQuantity { get; set; } 
        public string CategoryId { get; set; }
        public decimal Weight {  get; set; }
        public int EmployeeId {  get; set; }
        public bool isFamilyFriendly { get; set; }
        public long gtin8 { get; set; }    
        public string manufactur {  get; set; } 
        public int reviewID { get; set; }    
    }
}
