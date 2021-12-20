﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using SoloVova.Delivery.Backend.Desktop.Context;
using SoloVova.Delivery.Backend.Domain;

namespace SoloVova.Delivery.Backend.Desktop{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{
        public MainWindow(){
            InitializeComponent();
        }

        public void HandleAdd(){
            var packages = new Packages{
                IdCreateUser = Guid.NewGuid(),
                IdDeliveryman = Guid.Empty,
                Id = Guid.NewGuid(),
                Title = "Test_Title",
                Details = "Test_Details",
                CreationDate = DateTime.Now,
                EditDate = null
            };

            Context.Context context = Context.Context.Instance();
            context.deliveryDbContext.Packages.Add(packages);
            context.deliveryDbContext.SaveChanges();
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e){
            for (int i = 0; i < 1000; i++){
                this.HandleAdd();    
            }
            
        }
    }
}