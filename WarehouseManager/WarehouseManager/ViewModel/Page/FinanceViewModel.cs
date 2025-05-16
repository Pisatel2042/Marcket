using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.DBContext;

namespace WarehouseManager.ViewModel.Page
{
    public class FinanceViewModel : ViewModelBase
    {

        private string _Revenue;
        public string Revenue { get{ return _Revenue; } set { _Revenue = value; OnPropertyChanged(); } }

        private string _DeliveryCount;
        public string DeliveryCount { get { return _DeliveryCount;  } set {_DeliveryCount = value; OnPropertyChanged(); } }

        public readonly FinanceDBContext FinanceDBContext;

      public  FinanceViewModel() 
        {
            var connectionString = "Server=DESKTOP-T5ODPOF;Database=Marcket ;Trusted_Connection=True;";
            FinanceDBContext = new FinanceDBContext(connectionString);

            Revenue = FinanceDBContext.GetRevenue();
            DeliveryCount = FinanceDBContext.GetTodaysDeliveryCount();



        }
    }
}
