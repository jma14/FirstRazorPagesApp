using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRazorPagesApp.Services
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Person LoadByID(int ID);
    }
}
