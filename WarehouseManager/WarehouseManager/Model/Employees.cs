using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Model
{
    public class Employees
    {
        public int id {  get; set; }    
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; } 
        public Boolean IsActive { get; set; }
        public Boolean IsCourier {  get; set; }

    }
}
