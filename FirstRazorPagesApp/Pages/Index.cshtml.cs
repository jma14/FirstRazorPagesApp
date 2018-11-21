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
        private readonly ICMSService _cmsservice;
        private readonly IHttpContextAccessor _context;
        public CMS cms;
        public IndexModel(IHttpContextAccessor context, ICMSService cmsservice)
        {
            _context = context;
            _cmsservice = cmsservice;
        }

        public void OnGet()
        {
            cms = _cmsservice.Get(_context);
        }
    }
}
