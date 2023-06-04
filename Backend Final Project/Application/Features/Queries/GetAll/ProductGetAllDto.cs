namespace Application.Features.Products.Queries.GetAll
{
    public class ProductGetAllDto
    {
        public string OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public bool IsOnSale { get; set; }
        public decimal? SalePrice { get; set; }
        public bool IsDeleted { get; set; }

        public ProductGetAllDto(string orderId, string name, decimal price, string picture, bool isOnSale, decimal salePrice, bool isDeleted)
        {
            OrderId = orderId;

            Name = name;

            Price = price;

            Picture = picture;

            IsOnSale = isOnSale;

            SalePrice = salePrice;

            IsDeleted = isDeleted;

        }
    }
}
