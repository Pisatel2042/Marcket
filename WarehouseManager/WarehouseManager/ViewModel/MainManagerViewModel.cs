using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using WarehouseManager.Command;
using WarehouseManager.View.Page;
using WarehouseManager.ViewModel.Page;

namespace WarehouseManager.ViewModel
{
    internal class MainManagerViewModel : ViewModelBase
    {

        private Brush Blue = (SolidColorBrush)new BrushConverter().ConvertFromString("#415a77");
        private Brush White = (SolidColorBrush)new BrushConverter().ConvertFromString("#778da9");
        // Main
        private Brush _buttonMainBackground;
        public Brush ButtonMainBackground{get { return _buttonMainBackground; }set{ _buttonMainBackground = value;OnPropertyChanged();}}

        private Brush _buttonMainForeground;
        public Brush ButtonMainForeground { get { return _buttonMainForeground; }set{ _buttonMainForeground = value; OnPropertyChanged();} }

        // Itogi
        private Brush _buttonItogiBackground;
        public Brush ButtonItogiBackground { get { return _buttonItogiBackground; } set { _buttonItogiBackground = value; OnPropertyChanged(); } }

        private Brush _buttonItogiForeground;
        public Brush ButtonItogiForeground { get { return _buttonItogiForeground; } set { _buttonItogiForeground = value; OnPropertyChanged(); } }
        
        // Prodcut
        private Brush _buttonProductBackground;
        public Brush ButtonProductBackground { get { return _buttonItogiBackground; } set { _buttonItogiBackground = value; OnPropertyChanged(); } }

        private Brush _buttonProductForeground;
        public Brush ButtonProductForeground { get { return _buttonProductForeground; } set { _buttonProductForeground = value; OnPropertyChanged(); } }


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
        public MainManagerViewModel() 
        {
            ButtonMainForeground = Blue;
            ButtonMainBackground = White;

            ButtonItogiForeground = Blue;
            ButtonItogiBackground = White;

            ButtonProductForeground = Blue;
            ButtonProductBackground = White;


            ChangingTheColor = new ReplayCommand(ChangeColor, CanChangeColor);
        }



        #region Command 
        public ICommand ChangingTheColor { get; set; }    
        private bool CanChangeColor(object obj)
        {
            return true;
        }

        private void ChangeColor(object obj)
        {
            string buttonName = obj as string;
            ButtonMainForeground = Blue;
            ButtonMainBackground = White;

            ButtonItogiForeground = Blue;
            ButtonItogiBackground = White;

            ButtonProductForeground = Blue;
            ButtonProductBackground = White;

            switch (buttonName)
            {
                case "MainButton":
                    ButtonMainBackground = Blue;
                    ButtonMainForeground = White;
                    CurrentView = new MainPag();
                    break;
                case "FinanceButton":
                    ButtonItogiBackground = Blue;
                    ButtonItogiForeground = White;
                    CurrentView = new Finance();
                    break;
                case "ProductButton":
                    CurrentView = new Products();
                    ButtonProductBackground = Blue;
                    ButtonProductForeground = White;
                    break;
            }
            
        }

        #endregion
    }
}
