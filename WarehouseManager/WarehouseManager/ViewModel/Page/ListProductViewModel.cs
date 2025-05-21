using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Input;
using WarehouseManager.Command;
using WarehouseManager.DBContext;
using WarehouseManager.Model;
using WarehouseManager.View.Page.DialogBox;
using WarehouseManager.ViewModel.DialogBox;

namespace WarehouseManager.ViewModel.Page
{
    public class ListProductViewModel :ViewModelBase
    {
        #region DataContext
        private int id;
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }

        private string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }

        private decimal price;
        public decimal Price { get { return price; } set { price = value; OnPropertyChanged(); } }

        private string image;
        public string  Image { get { return image; } set { image = value; OnPropertyChanged(); }  }

        private string description;
        public string Description { get { return description; } set { description = value; OnPropertyChanged(); } }

        private int stockQuantity;
        public int StockQuantity { get { return stockQuantity; } set { stockQuantity = value; OnPropertyChanged(); } }

        private int categoryId;
        public int CategoryId { get { return categoryId; } set { categoryId = value; OnPropertyChanged(); } }

        private decimal weight;
        public decimal Weight { get{return  weight; } set{ weight = value; OnPropertyChanged();  } }

        private int employeeId;
        public int EmployeeId { get { return employeeId; } set { employeeId = value; OnPropertyChanged(); } }

        private ObservableCollection<Product> _product;
        public ObservableCollection<Product> Products { get { return _product; } set {  _product = value; OnPropertyChanged(); } }

        #endregion



        public ObservableCollection<Product> products { get; set; }
        public readonly ProductDBContext dBContext;
        public ListProductViewModel()
        {
            var connectionString = "Server=DESKTOP-T5ODPOF;Database=Marcket ;Trusted_Connection=True;";
            dBContext = new ProductDBContext(connectionString);
            LoadData();



            DeleteCommand = new ReplayCommand(Delete, CanDelete);
            EditCommand = new ReplayCommand(Edit, CanEdit);
        }

        

        private bool CanEdit(object obj)
        {
            return true;
        }

        private void Edit(object obj)
        {
          
        }

        private bool CanDelete(object obj)
        {
            return true;
        }

        private void Delete(object obj)
        {
            ProdcutDeleteWindow prodcutDeleteWindow = new ProdcutDeleteWindow();
            
            prodcutDeleteWindow.Show();
        }

        public void LoadData()
        {
           

            Products = dBContext.GetProduct();
            
        }


        #region Command 
        public ICommand DeleteCommand;

        public ICommand EditCommand;
        #endregion
    }
}
