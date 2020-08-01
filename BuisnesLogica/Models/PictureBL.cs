using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogica.Models
{
    public class PictureBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public string Image { get; set; }
        public int ChildId { get; set; }
        public ChildCardBL Child { get; set; }
    }
}
