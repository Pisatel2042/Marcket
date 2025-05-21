using LiveCharts;
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

        #region Axes
        private ChartValues<int> _PurchaseValues;
        public ChartValues<int> PurchaseValues { get { return _PurchaseValues; } set { _PurchaseValues = value; OnPropertyChanged(); } }

        private string[] _HoursLabels;
        public string[] HoursLabels { get { return _HoursLabels; } set { _HoursLabels = value; OnPropertyChanged(); } }

        private Func<double, string> _YFormatter;
        public Func<double, string> YFormatter { get { return _YFormatter; } set { _YFormatter = value; OnPropertyChanged(); } }

        #endregion


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
            DeliveryCount = FinanceDBContext.GetTodaysDeliveryCount().ToString();
        }


       public void Chart()
        {

            //var purchasesData = 123 ;
            //PurchaseValues = new ChartValues<int>(purchasesData);
            YFormatter = value => value.ToString("N0");
            HoursLabels = new string[24];
            for (int i = 0; i < 24; i++)
            {
                HoursLabels[i] = $"{i}";
            }
        }
    }
}
