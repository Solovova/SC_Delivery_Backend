namespace SoloVova.Delivery.Backend.Persistence{
    public class DbInitializer{
        public static void Initialize(DeliveryDbContext context){
            context.Database.EnsureCreated();
        }
    }
}