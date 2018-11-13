using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRazorPagesApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstRazorPagesApp.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        private IPersonService _person;

        public ContactModel(IPersonService person)
        {
            _person = person;
        }

        [BindProperty]
        public Person _Person { get; set; }

        public void OnGet(int? id)
        {
            Message = "Your contact page.";
            if(id.HasValue)
            {
                _Person = _person.LoadByID(id.Value);
            }
            else
            {
                _Person = new Person();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }
}
