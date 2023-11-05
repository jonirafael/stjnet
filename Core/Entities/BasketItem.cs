namespace Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal HNAPPN { get; set; }
        public int Quantity { get; set; }
        public decimal Disc { get; set; }
        public string PictureURL { get; set; }
        public string Category { get; set; }
        public string Factory { get; set; }
    }
}