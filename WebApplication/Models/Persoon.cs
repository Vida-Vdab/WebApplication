using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Models
{
    public class Persoon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string Voornaam { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\S+@{1}\S+\.{1}[a-z]+" , ErrorMessage = "Emailadres is niet geldig")]
        [Required(ErrorMessage = "Email is verplicht")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefoon is verplicht")]
        public string Telefoon { get; set; }

        [DataType(DataType.Date)]
        [Remote("ValideerGeboortedatum", "NieuwsBrief")]
        [Required(ErrorMessage = "Geboortedatum is verplicht")]
        public DateTime Geboortedatum { get; set; }

    }
}
