using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using WarehouseManager.Command;

namespace WarehouseManager.ViewModel.Page
{
    public class Product : ViewModelBase
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
        #region Color 
        private Brush Blue = (SolidColorBrush)new BrushConverter().ConvertFromString("#5e69ee");
        private Brush White = (SolidColorBrush)new BrushConverter().ConvertFromString("#F4F4FB");

        private Brush _listProduct; 
        public Brush ListProduct { get { return _listProduct; } set { _listProduct =  value; OnPropertyChanged(); } }
        private Brush _History;
        public Brush History { get { return _History; } set { _History = value; OnPropertyChanged(); } }

        private Brush _ListPTextColor ;
        public Brush ListPTextColor { get { return _ListPTextColor;} set {_ListPTextColor = value; OnPropertyChanged(); } }

        private Brush _HistoryPTextColor ;
        public Brush HistoryTextColor { get { return _HistoryPTextColor;} set { _HistoryPTextColor = value; OnPropertyChanged(); } }
        #endregion
        public Product() 
        {
            command = new ReplayCommand(Comm, CanCommand);
           
            ListPTextColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#6F7782");
            
            HistoryTextColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#6F7782");
        }

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
                    //CurrentView = 
                    break;
                case "History":
                    HistoryTextColor = Blue;
                    History = Blue;
                    break;

            }

        }

        public ICommand command {  get; set; }
    }
}
