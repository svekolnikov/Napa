using Napa.Interfaces;

namespace Napa.ConsoleTests;

public class VatTest
{
    private readonly IProductService _productService;

    public VatTest(IProductService productService)
    {
        _productService = productService;
    }

    [Fact]
    public void GetTotalPriceWithVatTest()
    {
        //Arrange

        //Act

        //Assert
    }
}