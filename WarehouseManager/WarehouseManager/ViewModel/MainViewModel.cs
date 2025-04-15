using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseManager.Command;
using WarehouseManager.View;

namespace WarehouseManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel() 
        {

            Open = new ReplayCommand(open, CanOpne);
        }

        private bool CanOpne(object obj)
        {
           return true;
        }

        private void open(object obj)
        {
           MainManagerWindows mainManagerWindows = new MainManagerWindows();
            mainManagerWindows.Show();
        }

        public ICommand Open {  get; set; } 
    }
}
