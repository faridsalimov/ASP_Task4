using ASP_Task4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Task4.Pages
{
    public class EditModel : PageModel
    {
        private readonly ProductDbContext _context;

        public EditModel(ProductDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            var productToUpdate = _context.Products.FirstOrDefault(p => p.ID == id);
            Product = productToUpdate;
        }

        [BindProperty]
        public Entities.Product Product { get; set; }

        public IActionResult OnPost(int id)
        {
            var productToUpdate = _context.Products.FirstOrDefault(p => p.ID == Product.ID);
            
            if (productToUpdate != null)
            {
                productToUpdate.Name = Product.Name;
                productToUpdate.Price = Product.Price;
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}