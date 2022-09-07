namespace Product.DataContracts.Requests
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public string SkuCode { get; set; }
        public int Price { get; set; }
    }
}
