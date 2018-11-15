using FirstRazorPagesApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRazorPagesApp.Services
{
    public interface IMemberService
    {
        List<Member> GetAll();
        Member LoadByID(int ID);
        void Save(Member member);
    }
}
