using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Data.Entity;

namespace DataAccess.Repozitoriy
{
    public class ChildCardRepoz
    {
        public List<ChildCardModel> GetAllCards()
        {
            using (var ctx = new DataContext())
            {
                List<ChildCardModel> allCards = ctx.ChildCards.Include(x => x.Pictures).ToList();
                ctx.SaveChanges();
                return allCards;
            }
        }
        public List<PictureModel> GetPictures(ChildCardModel card)
        {
            using (var ctx = new DataContext())
            {
                List<PictureModel> allPictures = ctx.ChildCards.Include(x => x.Pictures).FirstOrDefault(i => i.Id == card.Id).Pictures;
                ctx.SaveChanges();
                return allPictures;
            }
        }

        public ChildCardModel GetChildCardsById(int? id)
        {
            using (var ctx = new DataContext())
            {
                var childCard = ctx.ChildCards.Include(x => x.Pictures).FirstOrDefault(x => x.Id == id);

                ctx.SaveChanges();
                return childCard;
            }
        }

        public void DeleteChildCardById(int? id)
        {
            using (var ctx = new DataContext())
            {
                var childCard = ctx.ChildCards.Include(x => x.Pictures).FirstOrDefault(x => x.Id == id);
                ctx.ChildCards.Remove(childCard);
                ctx.SaveChanges();
            }
        }

        public void EditChildCard(ChildCardModel card)
        {
            using (var ctx = new DataContext())
            {
                var childCard = ctx.ChildCards.Include(x => x.Pictures).FirstOrDefault(x => x.Id == card.Id);
                childCard.Name = card.Name;
                childCard.LastName = card.LastName;
                childCard.Age = card.Age;               
                ctx.Entry(childCard).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public void AddChildCard(ChildCardModel card)
        {
            using (var ctx = new DataContext())
            {
                ctx.ChildCards.Add(card);
                ctx.SaveChanges();
            }
        }
        public void AddPicture(ChildCardModel card, PictureModel picture)
        {
            using (var ctx = new DataContext())
            {
                var childCard = ctx.ChildCards.Include(x => x.Pictures).FirstOrDefault(x => x.Id == card.Id);
                
                childCard.Pictures.Add(picture);
               
                ctx.SaveChanges();
            }

        }

    }
}

