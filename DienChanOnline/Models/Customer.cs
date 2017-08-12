using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetaPoco;

namespace DienChanOnline.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your first name.")]
        [DisplayName(@"First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your last name.")]
        [DisplayName(@"Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your phone number.")]
        [DisplayName(@"Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your email.")]
        [StringLength(50)]
        [DisplayName(@"Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your birthday.")]
        public DateTime? BirthDay { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your job title.")]
        [DisplayName(@"Job Title")]
        public string Job { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your address.")]
        [DisplayName(@"Address 1")]
        public string Address1 { get; set; }

        [DisplayName(@"Address 2")]
        public string Address2 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your city.")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your state.")]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your zip code.")]
        [DisplayName(@"Zip Code")]
        public string Zip { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your country.")]
        [DisplayName(@"Country")]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your purpose.")]
        public string Purpose { get; set; }

        public int FormId { get; set; }

        public Form Form { get; set; }

        [NotMapped]
        public string Title { get; set; }

        [NotMapped]
        public string Language { get; set; }
    }
}