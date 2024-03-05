using APITest.Controllers;
using APITest.Models;
using APITest.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace APITest.Test
{
    public class ProductsControllerTest
    {
        private Mock<IProductService> _productService;
        private List<Product> products;
        private Product product;

        [SetUp]
        public void Setup()
        {
            _productService = new Mock<IProductService>();
            products = new List<Product>();
            products.Add(new Product { Id = 1, ProductName = "Test", ProductAmount = 123 });
            products.Add(new Product { Id = 2, ProductName = "Test", ProductAmount = 123 });

            product = new Product
            {
                Id = 1,
                ProductName = "Test",
                ProductAmount = 123
            };
        }

        [Test]
        public void GetProductsTest()
        {
            //Act
            _productService.Setup(a => a.GetAllProducts()).Returns(products.ToList());

            //Arrange

            var productController = new ProdcutsController(_productService.Object);
            var productList = productController.GetAllProducts();

            //Assert
            var result = productList.Result as OkObjectResult;
            Assert.IsTrue(result.StatusCode == 200);
            Assert.IsNotNull(result);

        }

        [Test]
        public void GetProductByIdTest()
        {
            
            //Act
            _productService.Setup(a => a.GeProductById(It.IsAny<int>())).Returns(product);

            //Arrange

            var productController = new ProdcutsController(_productService.Object);
            var productById = productController.GetProductbyId(1) ;

            //Assert
            var result = productById.Result as OkObjectResult;

            Assert.IsTrue(result.StatusCode == 200);
            Assert.IsNotNull(result);

        }

        [Test]
        public void AddProductTest()
        {
            //Act
            _productService.Setup(a => a.AddProduct(product)).Returns(product);

            //Arrange

            var productController = new ProdcutsController(_productService.Object);
            var addedProduct = productController.AddProduct(product);

            //Assert
            var result = addedProduct as CreatedAtActionResult;

            Assert.IsTrue(result.StatusCode == 201);
            Assert.IsNotNull(result);

        }

        [Test]
        public void RemoveProductTest()
        {
            //Act

            _productService.Setup(a => a.GeProductById(2)).Returns(product);
            _productService.Setup(a => a.RemoveProduct(2)).Returns(product);

            //Arrange

            var productController = new ProdcutsController(_productService.Object);
            var deletedProduct = productController.RemoveProduct(2);

            //Assert
            var result = deletedProduct as OkObjectResult;

            Assert.IsTrue(result.StatusCode == 200);
            Assert.IsNotNull(result);

        }

    }
}