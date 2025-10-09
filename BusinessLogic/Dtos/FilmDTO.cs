using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int release_year { get; set; }

        public string genre { get; set; }
        public bool is_active { get; set; }
    }
}
