namespace Product.DataContracts.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SkuCode { get; set; }
        public int Price { get; set; }
    }
}
