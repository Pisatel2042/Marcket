﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WarehouseManager.ViewModel.Page;

namespace WarehouseManager.View.Page
{
    /// <summary>
    /// Логика взаимодействия для Finance.xaml
    /// </summary>
    public partial class Finance 
    {
        public Finance()
        {
            InitializeComponent();
            FinanceViewModel viewModel = new FinanceViewModel();
            DataContext = viewModel;
        }
    }
}
