using Product.Domain.Entities.Base;

namespace Product.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string SkuCode { get; set; }
        public int Price { get; set; }
    }
}
