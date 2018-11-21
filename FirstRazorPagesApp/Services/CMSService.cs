using FirstRazorPagesApp.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRazorPagesApp.Services
{
    public class CMSService : ICMSService
    {
        public CMS Get(IHttpContextAccessor context)
        {
            return new CMS(context);
        }
    }
}
