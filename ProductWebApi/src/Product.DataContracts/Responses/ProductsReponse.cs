using Product.DataContracts.Dtos;

namespace Product.DataContracts.Responses
{
    public class ProductsPaginationReponse
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }
}
