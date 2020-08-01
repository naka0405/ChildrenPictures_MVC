using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataAccess.Repozitoriy
{
    public class PictureRepoz
    {
        public List<PictureModel> GetAllPictures()
        {
            using (var ctx = new DataContext())
            {
                List<PictureModel> allPictures = ctx.Pictures.ToList();
                ctx.SaveChanges();
                return allPictures;
            }
        }
        public PictureModel GetPictureById(int? id)
        {
            using (var ctx = new DataContext())
            {
                var picture = ctx.Pictures.FirstOrDefault(x => x.Id == id);

                ctx.SaveChanges();
                return picture;
            }
        }

        public void DeletePictureById(int? id)
        {
            using (var ctx = new DataContext())
            {
                var picture = ctx.Pictures.FirstOrDefault(x => x.Id == id);
                ctx.Pictures.Remove(picture);
                ctx.SaveChanges();
            }
        }

        public void EditPicture(PictureModel picture)
        {
            using (var ctx = new DataContext())
            {
                var pict= ctx.Pictures.FirstOrDefault(x => x.Id == picture.Id);
                pict.Name = picture.Name;
                pict.Data = picture.Data;
                pict.Image= picture.Image;
                pict.ChildId = picture.ChildId;
                pict.Child = picture.Child;
                ctx.Entry(pict).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public ChildCardModel AddPicture(PictureModel picture, int? id)
        {
            using (var ctx = new DataContext())
            {
                var childCard = ctx.ChildCards.Include(x => x.Pictures).FirstOrDefault(x => x.Id == id);
                childCard.Pictures.Add(picture);
                //ctx.Pictures.Add(picture);
                ctx.SaveChanges();
                return childCard;
            }
        }
    }
}
