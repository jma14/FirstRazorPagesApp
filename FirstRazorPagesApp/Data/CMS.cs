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

        public CMS(IHttpContextAccessor context)
        {
            PageID = (int)context.HttpContext.Items["PageID"];
        }
    }
}
