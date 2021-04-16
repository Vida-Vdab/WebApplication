using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Bestelling
    {
        public Pastasoort Pastasoort { get; set; }
        public Grootte Grootte { get; set; }
        public Saus Saus { get; set; }
    }
}
