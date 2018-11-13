using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRazorPagesApp
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public Person()
        {

        }
        public Person(int id, string firstname, string lastname, string email)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }
    }
}
