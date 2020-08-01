using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogica.Models
{
    public class ChildCardBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<PictureBL> Pictures { get; set; }
        public ChildCardBL()
        {
            Pictures = new List<PictureBL>();
        }
    }
}
