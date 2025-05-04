using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;
using WarehouseManager.Command;
using WarehouseManager.DBContext;
using WarehouseManager.Model;
using WarehouseManager.View.Page;

namespace WarehouseManager.ViewModel.Page
{
    internal class ProductViewModel : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<CategoryProduct> _categoryProducts; 
        public ObservableCollection<CategoryProduct> categoryProducts { get { return _categoryProducts; } set { _categoryProducts = value; OnPropertyChanged(); } }

        private ObservableCollection<CategoryProduct> _selectCategory;
        public ObservableCollection<CategoryProduct> selectCategory { get { return _selectCategory; } set {  _selectCategory = value; OnPropertyChanged(); } }


        private ObservableCollection<Employees> _employess;
        public ObservableCollection<Employees> employees { get { return _employess; } set { _employess = value; OnPropertyChanged(); } }

        private ObservableCollection<Employees> _selectEmplyees;
        public ObservableCollection<Employees> selectEmplyees { get { return _selectEmplyees; } set { _selectEmplyees = value; OnPropertyChanged(); } }


        private ObservableCollection<Manufactur> _manufacter;
        public ObservableCollection<Manufactur> manufactur { get { return _manufacter; } set { _manufacter = value; OnPropertyChanged(); } }

        private ObservableCollection<Manufactur> _selectManufactur;
        public ObservableCollection<Manufactur> selectManufactur { get { return _selectManufactur; } set { _selectManufactur = value; OnPropertyChanged(); } }


        public readonly ProductDBContext dBContext;
        #region Color 
        private Brush Blue = (SolidColorBrush)new BrushConverter().ConvertFromString("#5e69ee");
        private Brush White = (SolidColorBrush)new BrushConverter().ConvertFromString("#F4F4FB");

        private Brush _listProduct;
        public Brush ListProduct { get { return _listProduct; } set { _listProduct = value; OnPropertyChanged(); } }
        private Brush _History;
        public Brush History { get { return _History; } set { _History = value; OnPropertyChanged(); } }

        private Brush _ListPTextColor;
        public Brush ListPTextColor { get { return _ListPTextColor; } set { _ListPTextColor = value; OnPropertyChanged(); } }

        private Brush _HistoryPTextColor;
        public Brush HistoryTextColor { get { return _HistoryPTextColor; } set { _HistoryPTextColor = value; OnPropertyChanged(); } }
        #endregion
        public ProductViewModel()
        {
           

            var connectionString = "Server=DESKTOP-T5ODPOF;Database=Marcket ;Trusted_Connection=True;";
            dBContext = new ProductDBContext(connectionString);

            command = new ReplayCommand(Comm, CanCommand);

            ListPTextColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#6F7782");
            HistoryTextColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#6F7782");

            EmpList = new ObservableCollection<string>();
            LoadCombobox();
        }

        #region Методы
        public ObservableCollection<string> EmpList { get; set; }
        public void LoadCombobox()
        {
            categoryProducts = dBContext.GetСategory();
           // employees = dBContext.GetEmployees();
            manufactur = dBContext.GetManufactur();


            ObservableCollection<Employees> EmployeeList = dBContext.GetEmployees();
            var emploPl = EmployeeList.Select(e => $" {e.id} {e.LastName} {e.Name[0]}. {e.FirstName[0]}.");
            foreach (var empployeeF in emploPl)
            {
                EmpList.Add(empployeeF);
            }

        
        }
         public Employees Emp;
        #endregion
        private bool CanCommand(object obj)
        {
            return true;
        }

        private void Comm(object obj)
        {
            string name = (string)obj;
            ListProduct = White;
            ListPTextColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#6F7782");
            History = White;
            HistoryTextColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#6F7782");
            switch (name)
            {
                case "ListP":
                    ListProduct = Blue;
                    ListPTextColor = Blue;
                    CurrentView = new ListProduct();
                    //CurrentView = 
                    break;
                case "History":
                    HistoryTextColor = Blue;
                    History = Blue;
                    break;

            }

        }

        public ICommand command { get; set; }
    }
}
