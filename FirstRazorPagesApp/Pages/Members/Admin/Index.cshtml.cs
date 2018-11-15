using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRazorPagesApp.Services;
using FirstRazorPagesApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstRazorPagesApp.Pages
{
    public class MembersAdminIndexModel : PageModel
    {

        private readonly IMemberService _member;

        public MembersAdminIndexModel(IMemberService member)
        {
            _member = member;
        }

        [BindProperty]
        public Member _Member { get; set; }

        public void OnGet(int? id)
        {
            if(id.HasValue)
            {
                _Member = _member.LoadByID(id.Value);
            }
            else
            {
                _Member = new Member();
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
                _member.Save(_Member);
                return RedirectToPage("/Members/Index");
            }
        }
    }
}
