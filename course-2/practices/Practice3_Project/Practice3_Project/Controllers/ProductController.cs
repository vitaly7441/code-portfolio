using Microsoft.AspNetCore.Mvc;
using Practice3_Project.DTO;

namespace Practice3_Project.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class ProductController : ControllerBase
//{
//    List<ProductDto> productDtos = new List<ProductDto>();

//    [HttpPost("add-product")]
//    public void AddProduct() {
//        productDtos.Add(
//            new ProductDto(001, "Product1", 1000)
//        );
//    }

//    [HttpGet("get-products")]
//    public List<ProductDto> GetProductDtos() {
//        return productDtos;
//    }
//}




[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private static List<ProductDto> _productDtos = new();

    [HttpPost("add-product")]
    public void AddProduct()
    {
        _productDtos.Add(new ProductDto(1, "Product1", 1000));
        
    }

    [HttpGet("get-products")]
    public IActionResult GetProductDtos()
    {
        return Ok(_productDtos);
    }
}
