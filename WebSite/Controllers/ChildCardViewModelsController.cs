using AutoMapper;
using BuisnesLogica;
using BuisnesLogica.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

using WebSite.Models;

namespace WebSite.Controllers
{
    public class ChildCardViewModelsController : Controller
    {
        private readonly CardManager _cardManager;
        private readonly Mapper _mapper;
        public ChildCardViewModelsController()
        {
            _cardManager = new CardManager();
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<ChildCardBL,ChildCardViewModel > ();
                x.CreateMap<ChildCardViewModel, ChildCardBL>();
                x.CreateMap<PictureBL, PictureViewModel> ();
                x.CreateMap<PictureViewModel, PictureBL>();

            });
            _mapper = new Mapper(config);
        }
        // GET: ChildCardViewModels
        public ActionResult Index()
        {
            var allCardsBL = _cardManager.GetChildCards();
            var allCards = _mapper.Map<List<ChildCardViewModel>>(allCardsBL);
            return View(allCards);
        }

        // GET: ChildCardViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cardBL = _cardManager.GetChildCardById(id);

            var card = _mapper.Map<ChildCardViewModel>(cardBL);
           
            if (card== null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // GET: ChildCardViewModels/Details/5
        public ActionResult Pictures(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cardBL = _cardManager.GetChildCardById(id);

            var card = _mapper.Map<ChildCardViewModel>(cardBL);
         
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pictures(ChildCardViewModel childCardViewModel)
        {
                var cardBL = _mapper.Map<ChildCardBL>(childCardViewModel);
               var allPictures= _cardManager.GetPictures(cardBL);
               
            return View(allPictures);
        }

        // GET: ChildCardViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChildCardViewModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,Age")] ChildCardViewModel childCardViewModel)
        {
            if (ModelState.IsValid)
            {
                var cardBL = _mapper.Map<ChildCardBL>(childCardViewModel);
                _cardManager.AddChildCard(cardBL);
                
                return RedirectToAction("Index");
            }

            return View(childCardViewModel);
        }

        // GET: ChildCardViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cardBL=_cardManager.GetChildCardById(id);
            
            if (cardBL == null)
            {
                return HttpNotFound();
            }
            var card = _mapper.Map<ChildCardViewModel>(cardBL);
            return View(card);
        }

        // POST: ChildCardViewModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Age,Pictures")] ChildCardViewModel childCardViewModel)
        {
            if (ModelState.IsValid)
            {              
                var cardBL = _mapper.Map<ChildCardBL>(childCardViewModel);
                _cardManager.EditChildCard(cardBL);
                return RedirectToAction("Index");
            }
            return View(childCardViewModel);
        }

        // GET: ChildCardViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var childCardBL = _cardManager.GetChildCardById(id);

            if (childCardBL == null)
            {
                return HttpNotFound();
            }
            var card = _mapper.Map<ChildCardViewModel>(childCardBL);

            return View(card);
        }

        // POST: ChildCardViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {            
            _cardManager.DeleteCard(id);                      
            return RedirectToAction("Index");
        }       
    }
}
