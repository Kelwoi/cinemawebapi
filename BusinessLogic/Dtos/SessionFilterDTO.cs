using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class SessionFilterDTO
    {
        public int? MovieId { get; set; }
        public int? HallId { get; set; }
        public DateTime? StartAfter { get; set; }
        public DateTime? StartBefore { get; set; }
    }
}
