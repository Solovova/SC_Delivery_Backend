namespace SoloVova.Delivery.Backend.Persistence{
    public static class DbInitializer{
        public static void Initialize(DeliveryDbContext context){
            context.Database.EnsureCreated();
        }
    }
}