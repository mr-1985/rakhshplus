using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Context;

namespace MyShop.Web.Pages.Admin.Product
{
    public class IndexModel : PageModel
    {
        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<DataLayer.Entities.Product> Products { get; set; }
        public void OnGet()
        {
            Products = _productService.GetAllProducts();
        }
    }
}
