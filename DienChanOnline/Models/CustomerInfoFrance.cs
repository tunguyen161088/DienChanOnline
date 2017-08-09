using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace DienChanOnline.Models
{
    [TableName("DienChanOnline..CustomerInfo")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class CustomerInfoFrance
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Entrez votre prénom s'il vous plait.")]
        [DisplayName(@"Prénom")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Veuillez entrer votre nom de famille.")]
        [DisplayName(@"Nom")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Veuillez entrer votre tel.")]
        [DisplayName(@"Tel")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Veuillez entrer votre email.")]
        [DisplayName(@"Email")]
        public string Email { get; set; }

        [DisplayName(@"Anniversaire")]
        [Required(AllowEmptyStrings = false, ErrorMessage = @"Veuillez entrer votre anniversaire.")]
        public DateTime BirthDay { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Entrez votre titre de travail.")]
        [DisplayName(@"Metier")]
        public string Job { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Veuillez entrer votre adresse.")]
        [DisplayName(@"Adresse 1")]
        public string Address1 { get; set; }

        [DisplayName(@"Adresse 2")]
        public string Address2 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Veuillez entrer votre ville.")]
        [DisplayName(@"Ville")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Veuillez entrer votre etat.")]
        [DisplayName(@"Etat")]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Veuillez entrer votre code postal.")]
        [DisplayName(@"Code Postale")]
        public string Zip { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Entrez votre pays s'il vous plaît.")]
        [DisplayName(@"Pays")]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Entrez votre objectif s'il vous plaît.")]
        [DisplayName(@"Objectif")]
        public string Purpose { get; set; }

        public string Title { get; set; }

        public string FormGuidInfo { get; set; }
    }
}