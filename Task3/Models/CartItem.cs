namespace Task3.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
    }
}