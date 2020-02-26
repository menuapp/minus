using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using WebService.DTOs;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService { get; set; }
        private IProductCategoryService productCategoryService { get; set; }
        private IMapper mapper { get; set; }
        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IMapper mapper)
        {
            this.productService = productService;
            this.productCategoryService = productCategoryService;
            this.mapper = mapper;
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var categories = mapper.Map<List<ProductCategoryDto>>(productCategoryService.GetMany(cat => cat.Partner.AssociateName == name));
            return Ok(categories);
        }
    }
}