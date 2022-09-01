using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Pages.Admin.Product
{
    public class CreateProductModel : PageModel
    {
        private IProductService _productService;

        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty] public DataLayer.Entities.Product Product { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {

               


                return Page();
            }

            _productService.AddProduct(Product);
            return RedirectToPage("Index");
        }
    }
}
