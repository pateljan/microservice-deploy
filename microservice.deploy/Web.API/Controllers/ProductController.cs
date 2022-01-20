using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Data;
using Web.API.Models;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _productContext;

        public ProductController(ILogger<ProductController> logger, ProductContext productContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productContext.Products.Find(p => true).ToListAsync();
        }
    }
}
