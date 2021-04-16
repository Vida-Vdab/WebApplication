using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class PersoonService
    {
        private Dictionary<int, Persoon> nieuwsbrief = new Dictionary<int, Persoon>();

        public void Add(Persoon p) 
        { 
            if(nieuwsbrief.Count != 0)
            {
                p.Id = nieuwsbrief.Keys.Max() + 1;
            }
           else
            {
                p.Id = 1;
            }

            nieuwsbrief.Add(p.Id, p); 
        }
    }
}
