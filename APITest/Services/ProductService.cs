using APITest.Models;

namespace APITest.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    ProductName = "Test",
                    ProductAmount = 123
                },
                new Product()
                {
                    Id = 2,
                    ProductName = "Test",
                    ProductAmount = 123
                },
                new Product()
                {
                    Id = 3,
                    ProductName = "Test",
                    ProductAmount = 123
                },
                 new Product()
                {
                    Id = 4,
                    ProductName = "Test",
                    ProductAmount = 123
                },
            };
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product AddProduct(Product newProduct)
        {
            _products.Add(newProduct);
            return newProduct;
        }

        public Product GeProductById(int id)
        {
            return _products.FirstOrDefault(a => a.Id == id);
        }

        public Product RemoveProduct(int id)
        {
            var existing = _products.First(a => a.Id == id);
            _products.Remove(existing);
            return existing;
        }
    }
}
