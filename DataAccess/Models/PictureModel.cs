
namespace DataAccess.Models
{
    public class PictureModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public string Image { get; set; }
        public int ChildId { get; set; }
        public ChildCardModel Child { get; set; }
    }
}
