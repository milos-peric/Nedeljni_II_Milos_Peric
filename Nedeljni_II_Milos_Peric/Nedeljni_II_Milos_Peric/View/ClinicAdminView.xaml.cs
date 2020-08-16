﻿using Nedeljni_II_Milos_Peric.ViewModel;
using System;
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
using System.Windows.Shapes;

namespace Nedeljni_II_Milos_Peric.View
{
    /// <summary>
    /// Interaction logic for ClinicAdminView.xaml
    /// </summary>
    public partial class ClinicAdminView : Window
    {
        public ClinicAdminView(vwClinicAdmin clinicAdmin)
        {
            InitializeComponent();
            DataContext = new ClinicAdminViewModel(this, clinicAdmin);
        }
    }
}