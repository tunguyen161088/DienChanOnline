using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace DienChanOnline.Models
{
    [TableName("DienChanOnline..CustomerInfo")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class CustomerInfo
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
        [DisplayName(@"Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your birthday.")]
        public DateTime BirthDay { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Please enter your job title.")]
        [DisplayName(@"Job title")]
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

        public string Title { get; set; }

        public string FormGuidInfo { get; set; }
    }
}