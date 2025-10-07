using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppDb.Data.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MovieId { get; set; }
        public Film Movie { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
