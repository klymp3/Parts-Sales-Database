using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Shared
{
    public class _Layout : PageModel
    {
        public void OnGet()
        {

        }
        protected IActionResult OnPost(string action)
        {
            if (action == "addOrder")
            {
                return RedirectToPage("./Index");
            }
            else if (action == "addDetail")
            {
                return RedirectToPage("./AddDetail");
            }
            else if (action == "addProvider")
            {
                return RedirectToPage("./AddProvider");
            }
            else if (action == "addClient")
            {
                return RedirectToPage("./AddClient");
            }
            else return RedirectToPage("./Index");
        }
    }
}
