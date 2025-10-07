using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppDb.Data.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
