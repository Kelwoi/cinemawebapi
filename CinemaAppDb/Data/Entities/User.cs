using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppDb.Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime? Birthdate { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public decimal Balance { get; set; }
    }
}
