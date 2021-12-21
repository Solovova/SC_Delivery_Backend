using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoloVova.Delivery.Backend.Domain;

namespace SoloVova.Delivery.Backend.Application.Interfaces{
    public interface IDeliveryDbContext{
        DbSet<Package> Package{ get; set; }
        DbSet<Address> Address{ get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}