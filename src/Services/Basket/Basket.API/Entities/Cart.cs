namespace Basket.API.Entities
{
    public class Cart
    {
        public string? UserName { get; set; }
        public List<CartItem> CartItems { get; set; }  = new ();

        public Cart() { }

        public Cart(string userName)
        {
            UserName = userName ?? string.Empty;
        }

        public decimal TotalPrice 
        {
            get
            {
                decimal total = 0;
                foreach (var item in CartItems)
                {
                    total += item.Price * item.Quantity;
                }
                return total;
            }
        }
    }
}
