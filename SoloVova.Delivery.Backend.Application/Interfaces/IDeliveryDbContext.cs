using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoloVova.Delivery.Backend.Domain;

namespace SoloVova.Delivery.Backend.Application.Interfaces{
    public interface IDeliveryDbContext{
        DbSet<Packages> Packages{ get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}