using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger) 
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "ademk", FirstName = "Adem", LastName = "Kinatas", EmailAddress = "ademkinatas@gmail.com", AddressLine = "Istanbul", Country = "Turkey", TotalPrice = 350, CVV = string.Empty, CardName = string.Empty, CardNumber = string.Empty, CreatedBy = "ademk", CreatedDate = DateTime.Now, Expiration = string.Empty, LastModifiedBy = string.Empty, PaymentMethod = 0, State = "Active", ZipCode = string.Empty }
            };
        }
    }
}
