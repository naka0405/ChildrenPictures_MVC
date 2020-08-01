using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using BuisnesLogica;
using BuisnesLogica.Models;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class PictureViewModelsController : Controller
    {
        private readonly PictureManager _pictureManager;
        private readonly Mapper _mapper;

        public PictureViewModelsController()
        {
            _pictureManager = new PictureManager();
            var config = new MapperConfiguration(x =>
             {
                 x.CreateMap<PictureBL, PictureViewModel>();
                 x.CreateMap<PictureViewModel, PictureBL>();
                 x.CreateMap<ChildCardBL, ChildCardViewModel>();
                 x.CreateMap<ChildCardViewModel, ChildCardBL>();
             });
            _mapper = new Mapper(config);
        }

        // GET: PictureViewModels
        public ActionResult Index()
        {
            var allPicturesBL = _pictureManager.GetAllPictures();
            var allPictures = _mapper.Map<List<PictureViewModel>>(allPicturesBL);
            return View(allPictures);
        }

        // GET: PictureViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pictureBL=_pictureManager.GetPictureById(id);
            if (pictureBL == null)
            {
                return HttpNotFound();
            }
            var pictureViewModel = _mapper.Map<PictureViewModel>(pictureBL);
            return View(pictureViewModel);
        }

        // GET: PictureViewModels/Create
        public ActionResult Create(int id)
        {     
            return View();
        }

        // POST: PictureViewModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Data,Image")] PictureViewModel pictureViewModel, int? id)
        {           
                var pictureBL = _mapper.Map<PictureBL>(pictureViewModel);
                var cardModel=_pictureManager.AddPicture(pictureBL,id);
            var cardViewModel = _mapper.Map<ChildCardViewModel>(cardModel);
                return View("~/Views/ChildCardViewModels/Pictures.cshtml",cardViewModel);
        }

        //GET: PictureViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pictureBL = _pictureManager.GetPictureById(id);
            if (pictureBL == null)
            {
                return HttpNotFound();
            }
            var picture = _mapper.Map<PictureViewModel>(pictureBL);
            return View(picture);
        }

        //POST: PictureViewModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку.
        // Дополнительные сведения см.в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Data,Image")] PictureViewModel pictureViewModel)
        {
            if (ModelState.IsValid)
            {
                var pictureBL = _mapper.Map<PictureBL>(pictureViewModel);
               _pictureManager.EditPicture(pictureBL);
                return RedirectToAction("Index");
            }           
            return View(pictureViewModel);
        }

        // GET: PictureViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pictureBL = _pictureManager.GetPictureById(id);
            if (pictureBL == null)
            {
                return HttpNotFound();
            }
            var picture = _mapper.Map<PictureViewModel>(pictureBL);
            return View(picture);
        }

        // POST: PictureViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _pictureManager.DeletePictureById(id);
            return RedirectToAction("Index");
        }
    }
}
