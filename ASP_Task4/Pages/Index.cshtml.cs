using ASP_Task4.Data;
using ASP_Task4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Task4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProductDbContext _context;

        public IndexModel(ProductDbContext context)
        {
            _context = context;
        }

        public List<Entities.Product> Products { get; set; }
        public string Info { get; set; }

        [BindProperty]
        public Entities.Product Product { get; set; }

        [BindProperty]
        public int ProductIdToDelete { get; set; }

        public void OnGet(string info = "")
        {
            Products = _context.Products.ToList();
            Info = info;
        }

        public IActionResult OnPost()
        {
            if (ProductIdToDelete > 0)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == ProductIdToDelete);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    Info = $"{product.Name} deleted successfully.";
                }
            }

            else
            {
                _context.Products.Add(Product);
                _context.SaveChanges();
                Info = $"{Product.Name} added successfully.";
            }

            return RedirectToPage("Index", new { info = Info });
        }
    }
}