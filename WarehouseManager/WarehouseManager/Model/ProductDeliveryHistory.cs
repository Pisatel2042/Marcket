using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Model
{
    public class ProductDeliveryHistory
    {
        public int Id { get; set; }
        public int OrderId   { get; set; }
        public DateTime EventTimestamp {  get; set; }
        public string EventType { get ; set; }  
        public string Description { get; set; }
        public string OrderStatus { get; set; }
        public string Location { get; set; }    
        public string EmployyeesID {  get; set; }   
        public string AdditionalData { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal OrderTotal { get; set; }

    }
}
