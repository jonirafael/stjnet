namespace API.Dtos;

public class ProductToReturnDto
{
    public int Id { get; set; }
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public string Uom { get; set; }
    public string Description { get; set; }
    public decimal HNAPPN { get; set; }
    public string PictureURL { get; set; }
    public string ProductFactory { get; set; }
    public string ProductCategory { get; set; }
}
