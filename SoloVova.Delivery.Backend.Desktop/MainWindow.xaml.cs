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
using SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.CreatePackage;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.DeletePackage;
using SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageList;
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
            var packages = new Package{
                IdCreateUser = Guid.NewGuid(),
                IdDeliveryman = Guid.Empty,
                Id = Guid.NewGuid(),
                Title = "Test_Title",
                Details = "Test_Details",
                CreationDate = DateTime.Now,
                EditDate = null
            };

            Context.Context context = Context.Context.Instance();
            context.deliveryDbContext.Package.Add(packages);
            context.deliveryDbContext.SaveChanges();
        }

        private void ButtonAddRowsSimple_OnClick(object sender, RoutedEventArgs e){
            Context.Context context = Context.Context.Instance();
            for (int i = 0; i < 10; i++){
                var address = new Address{
                    Name = "Ivano-Frankivsk str. Prom",
                    X = 1.233m,
                    Y = 1.56445m
                };
                var packages = new Package{
                    IdCreateUser = Guid.NewGuid(),
                    IdDeliveryman = Guid.Empty,
                    Id = Guid.NewGuid(),
                    Title = $"Test_Title{i}",
                    Details = $"Test_Details{i}",
                    CreationDate = DateTime.Now,
                    EditDate = null,
                    AddressFrom = address
                };

                //context.deliveryDbContext.Address.Add(address);
                context.deliveryDbContext.Package.Add(packages);
            }

            context.deliveryDbContext.SaveChanges();

            this.tb.Text += "\n Add1 - Ok";
        }

        private void ButtonAddRowsByCommands_OnClick(object sender, RoutedEventArgs e){
            var context = Context.Context.Instance();
            var createPackageCommandHandler = new CreatePackageCommandHandler(context.deliveryDbContext);
            var cancellationToken = new CancellationToken();
            for (int i = 0; i < 100; i++){
                var createPackagesCommand = new CreatePackageCommand{
                    IdCreateUser = Guid.NewGuid(),
                    Title = $"Test_Title{i}",
                    Details = $"Test_Details{i}",
                };
                createPackageCommandHandler.Handle(createPackagesCommand, cancellationToken);
            }

            this.tb.Text += "\n Add1 - Ok";
        }

        private void ButtonDeleteAll_OnClick(object sender, RoutedEventArgs e){
            var context = Context.Context.Instance();
            var getPackageListQueryHandler = new GetPackageListQueryHandler(context.deliveryDbContext);
            var cancellationToken = new CancellationToken();

            var listPackages =
                getPackageListQueryHandler.Handle(new GetPackageListQuery(){UserId = Guid.Empty}, cancellationToken);

            listPackages.ContinueWith(result => {
                if (result.IsCompletedSuccessfully){
                    foreach (var package in result.Result.Packages){
                        var deletePackageCommandHandler = new DeletePackageCommandHandler(context.deliveryDbContext);
                        deletePackageCommandHandler.Handle(new DeletePackageCommand(){Id =package.Id }, new CancellationToken());
                    }    
                }
            }, cancellationToken);
            

            this.tb.Text += "\n Delete - Ok";
        }
    }
}