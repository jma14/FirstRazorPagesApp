using FirstRazorPagesApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRazorPagesApp.Data
{
    public class Member
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public Member()
        {

        }

        public Member(int id, string firstname, string lastname, string title, string email)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Title = title;
            Email = email;
        }
    }
}
