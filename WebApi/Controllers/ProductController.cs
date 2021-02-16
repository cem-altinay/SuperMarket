using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.ProductService;
using Core.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;

        public ProductController(IProductService product)
        {
            _product = product;
        }


        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {

            var productList = _product.GetActiveProductList();
            if (productList != null && productList.Success)
            {
                return Ok(productList.Data);
            }

            return NotFound(new ErrorDetails()
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = "Ürün listesi bulunamadı"
            });

        }
    }
}
