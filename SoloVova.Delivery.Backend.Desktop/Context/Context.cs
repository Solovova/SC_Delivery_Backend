using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SoloVova.Delivery.Backend.Domain;
using SoloVova.Delivery.Backend.Persistence;

namespace SoloVova.Delivery.Backend.Desktop.Context
{
    public class Context{
        private static Context _instance;
        private static readonly object LockObject = new();
        public DeliveryDbContext deliveryDbContext;

        private Context(){
            var connectionString = "Data Source=Delivery.db";
            var options = new DbContextOptionsBuilder<DeliveryDbContext>()
                .UseSqlite(connectionString)
                .Options;
            deliveryDbContext = new DeliveryDbContext(options);
            deliveryDbContext.Database.EnsureCreated();
        }
        


        public static Context Instance(){
            lock (LockObject){
                _instance ??= new Context();
            }
            return _instance;
        }
    }
}