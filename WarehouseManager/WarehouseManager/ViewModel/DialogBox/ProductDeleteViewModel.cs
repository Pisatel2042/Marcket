using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseManager.Command;
using WarehouseManager.DBContext;

namespace WarehouseManager.ViewModel.DialogBox
{
    public class ProductDeleteViewModel : ViewModelBase
    {
        private string _NameProduct;
        public string NameProduct { get { return _NameProduct;} set { _NameProduct = value; OnPropertyChanged(); } }

        private string _IdProdcut;
        public string IdProdcut { get { return _IdProdcut; } set { _IdProdcut = value; OnPropertyChanged(); } }

        private string _BarCodeProduct;
        public string BarCodeProduct { get { return _BarCodeProduct; } set { _BarCodeProduct = value; OnPropertyChanged(); } }



        public ProductDeleteViewModel() 
        {

            

            

            DeleteButton = new ReplayCommand(Delete, CanDelete);
        }



        #region Command
        public ICommand DeleteButton;
        private bool CanDelete(object obj)
        {
            return true;
        }

        ProductDBContext dbContext;
        private void Delete(object obj)
        {
            dbContext.Delete(IdProdcut);
        }

        public ICommand ExitDelete;
        #endregion
    }
}
