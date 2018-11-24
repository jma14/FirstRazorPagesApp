using FirstRazorPagesApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FirstRazorPagesApp.Data
{
    public class CMS
    {
        public int PageID { get; }
        private readonly IHttpContextAccessor context;

        public CMS(IHttpContextAccessor _context)
        {
            context = _context;
            PageID = (int)context.HttpContext.Items["PageID"];
        }
    }
}
