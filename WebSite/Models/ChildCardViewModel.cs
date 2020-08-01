using System;
using System.Collections.Generic;


namespace WebSite.Models
{
    public class ChildCardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<PictureViewModel> Pictures { get; set; }
        public ChildCardViewModel()
        {
            Pictures = new List<PictureViewModel>();
        }
    }
}