using System;
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

        public async Task<int> HandleAdd(CancellationToken cancellationToken){
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
            await context.deliveryDbContext.Packages.AddAsync(packages, cancellationToken); 
            //await context.deliveryDbContext.SaveChangesAsync(cancellationToken);
            return 1;
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e){
            CancellationToken cancellationToken = new CancellationToken();
            var task = this.HandleAdd(cancellationToken);
            var result = task.GetAwaiter().GetResult();
        }
    }
}