using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRazorPagesApp.Services
{
    public class PersonService : IPersonService
    {
        public List<Person> GetAll()
        {
            return new List<Person>()
            {
                new Person(1,"Jason","Arnoff","jason@websolutions.com"),
                new Person(2,"Jackson","Smith","Mason@websolutions.com")
            };

        }

        public Person LoadByID(int ID)
        {
            return GetAll().Where(p => p.ID == ID).First();
        }
    }
}
