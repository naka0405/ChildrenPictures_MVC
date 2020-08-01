using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class ChildCardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<PictureModel> Pictures { get; set; }
        public ChildCardModel()
        {
            Pictures = new List<PictureModel>();
        }
    }
}
