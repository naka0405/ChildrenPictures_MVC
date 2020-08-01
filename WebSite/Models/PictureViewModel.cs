
namespace WebSite.Models
{
    public class PictureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public string Image { get; set; }
        public int ChildId { get; set; }
        public ChildCardViewModel Child { get; set; }
    }
}