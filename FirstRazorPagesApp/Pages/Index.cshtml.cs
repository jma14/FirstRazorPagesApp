using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRazorPagesApp.Data;
using FirstRazorPagesApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstRazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        public CMS cms;
        public IndexModel(CMS _cms)
        {
            cms = _cms;
        }

        public void OnGet()
        {
            
        }
    }
}
