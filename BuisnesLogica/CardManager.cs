using AutoMapper;
using BuisnesLogica.Models;
using DataAccess.Models;
using DataAccess.Repozitoriy;
using System;
using System.Collections.Generic;


namespace BuisnesLogica
{
    public class CardManager
    {
        private readonly ChildCardRepoz _childCardRepoz;
        private readonly Mapper _mapper;
        public CardManager()
        {
            _childCardRepoz = new ChildCardRepoz();
            var config = new MapperConfiguration(x =>
             {
                 x.CreateMap<ChildCardModel, ChildCardBL>();
                 x.CreateMap<ChildCardBL, ChildCardModel>();
                 x.CreateMap<PictureModel, PictureBL>();
             });
            _mapper = new Mapper(config);
        }

        public List<ChildCardBL>GetChildCards()
        {
            var allCards=_childCardRepoz.GetAllCards();
           var allCardsBl=_mapper.Map<List<ChildCardBL>>(allCards);
            return allCardsBl;
        }

        public ChildCardBL GetChildCardById(int? id)
        {
           var childCard= _childCardRepoz.GetChildCardsById(id);
           var childCardBl = _mapper.Map<ChildCardBL>(childCard);
            return childCardBl;
        }

        public List<PictureBL> GetPictures(ChildCardBL card)
        {
            var childCardModel = _mapper.Map<ChildCardModel>(card);
            var allPicturesDal = _childCardRepoz.GetPictures(childCardModel);
            var allPictures = _mapper.Map<List<PictureBL>>(allPicturesDal);
            return allPictures;
        }
         public void DeleteCard(int? id)
        {
             _childCardRepoz.DeleteChildCardById(id);
        }

        public void EditChildCard(ChildCardBL card)
        {
            var childCard = _mapper.Map<ChildCardModel>(card);
            _childCardRepoz.EditChildCard(childCard);
        }

        public void AddChildCard(ChildCardBL cardBL)
        {
            var card = _mapper.Map<ChildCardModel>(cardBL);
            _childCardRepoz.AddChildCard(card);
        }
        
        public void AddPicture(ChildCardBL cardBL, PictureBL pictureBL)
        {
            var card = _mapper.Map<ChildCardModel>(cardBL);
            var picture = _mapper.Map<PictureModel>(pictureBL);
            _childCardRepoz.AddPicture(card, picture);
        }     
    }
}
