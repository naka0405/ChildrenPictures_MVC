using AutoMapper;
using BuisnesLogica.Models;
using DataAccess.Models;
using DataAccess.Repozitoriy;
using System;
using System.Collections.Generic;

namespace BuisnesLogica
{
    public class PictureManager
    {
        private readonly PictureRepoz _pictRepozitoriy;
        private readonly Mapper _mapper;

        public PictureManager()
        {
            _pictRepozitoriy = new PictureRepoz();
            var config = new MapperConfiguration(x =>
              {
                  x.CreateMap<PictureModel, PictureBL>();
                  x.CreateMap<PictureBL, PictureModel>();
                  x.CreateMap<ChildCardModel, ChildCardBL>();
                  x.CreateMap<ChildCardBL, ChildCardModel>();
              });
            _mapper = new Mapper(config);
        }

        public List<PictureBL>GetAllPictures()
        {
            var allPictures = _pictRepozitoriy.GetAllPictures();
            var allPicturesBL = _mapper.Map<List<PictureBL>>(allPictures);
            return allPicturesBL;
        }

        public PictureBL GetPictureById(int? id)
        {
            var picture=_pictRepozitoriy.GetPictureById(id);
            var pictureBL = _mapper.Map<PictureBL>(picture);
            return pictureBL;
        }

        public void DeletePictureById(int? id)
        {
            _pictRepozitoriy.DeletePictureById(id);
        }

        public void EditPicture(PictureBL picture)
        {
            var pictureDAL = _mapper.Map<PictureModel>(picture);
            _pictRepozitoriy.EditPicture(pictureDAL);
        }
        public ChildCardBL AddPicture(PictureBL picture, int? id)
        {
            var pictureDAl = _mapper.Map<PictureModel>(picture);
            var card=_pictRepozitoriy.AddPicture(pictureDAl, id);
            var cardBL = _mapper.Map<ChildCardBL>(card);
            return cardBL;
        }
    }
}
