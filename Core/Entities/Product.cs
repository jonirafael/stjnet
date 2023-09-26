namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Uom { get; set; }
        public string Description { get; set; }
        public decimal HNAPPN { get; set; }
        public string PictureURL { get; set; }
        public bool isEnabled { get; set; }
        public ProductFactory ProductFactory { get; set; }
        public int ProductFactoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
    }
}