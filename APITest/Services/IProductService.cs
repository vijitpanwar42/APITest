using APITest.Models;

namespace APITest.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product GeProductById(int id);

        Product AddProduct(Product newProduct);

        Product RemoveProduct(int id);
    }
}
