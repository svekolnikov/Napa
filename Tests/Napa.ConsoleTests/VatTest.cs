using AutoMapper;
using Microsoft.Extensions.Options;
using Moq;
using Napa.DAL.Context;
using Napa.DTO.Options;
using Napa.Interfaces;
using Napa.MVC.Infrastructure.Automapper;
using Napa.Services;

namespace Napa.ConsoleTests;

public class VatTest
{
    private readonly Mock<IProductService> _mockProductService;
    private readonly Mock<ApplicationDbContext> _mockDbContext;
    private readonly Mock<IOptions<ConfigDetails>> _mockOptions;
    private readonly float _vat;
    private static IMapper _mapper;

    public VatTest()
    {
        _mockProductService = new Mock<IProductService>();

        _mockDbContext = new Mock<ApplicationDbContext>();

        _mockOptions = new Mock<IOptions<ConfigDetails>>();

        //VAT
        _vat = 0.15f;

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ProductProfile());
        });
        var mapper = mappingConfig.CreateMapper();
        _mapper = mapper;
    }

    [Fact]
    public void GetTotalPriceWithVatTest()
    {
        //Arrange
        var amount = 100;
        var price = 5;
        var expected = amount * price * (decimal)(1 + _vat);

        _mockProductService.Setup(productService =>
            productService.GetTotalPriceWithVat(amount, price))
            .Returns(expected);

        var service = new ProductService(_mockOptions.Object, _mockDbContext.Object, _mapper);

        //Act
        var actual = service.GetTotalPriceWithVat(amount, price);

        //Assert
        Assert.Equal(expected, actual);
    }
}