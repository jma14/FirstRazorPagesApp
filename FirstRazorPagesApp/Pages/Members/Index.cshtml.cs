using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRazorPagesApp.Data;
using FirstRazorPagesApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstRazorPagesApp.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly IMemberService _members;
        public List<Member> _Members { get; set; }

        public IndexModel(IMemberService members)
        {
            _members = members;
        }

        public void OnGet()
        {
            _Members = _members.GetAll();
        }
    }
}