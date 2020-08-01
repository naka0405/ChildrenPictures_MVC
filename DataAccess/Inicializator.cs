using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;


namespace DataAccess
{
    public class Inicializator:CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext ctx)
        {
            var child1 = new ChildCardModel() { Name = "Anisia", LastName = "Shkurkina", Age = 11 };
            var child2 = new ChildCardModel() { Name = "Petr", LastName = "Shkurkin", Age = 8 };
            var child3 = new ChildCardModel() { Name = "Pavel", LastName = "Shkurkin", Age = 5 };

            List<PictureModel> picturesAnisii = new List<PictureModel>()
            {
                new PictureModel(){Name="Spring", Data="12.06.2020", Image="/Images/Spring.jpg"},
                new PictureModel(){Name="My Hobby", Data="01.07.2020", Image="/Images/MyHobby.jpg"},
                new PictureModel(){Name="Dogs", Data="12.07.2020", Image="/Images/Dogs.jpg"}
            };
            
            child1.Pictures = picturesAnisii;
            var pictSummer = new PictureModel() { Name = "Summer", Data = "12.07.2020", Image= "/Images/Summer.jpg", Child = child2 };

            List<PictureModel> picturesPavla = new List<PictureModel>()
            {
                new PictureModel(){Name="Cars", Data="12.05.2020", Image="/Images/Cars.jpg"},
                new PictureModel(){Name="My Mother", Data="01.07.2020", Image="/Images/Mama.jpg"},                
            };
            child3.Pictures = picturesPavla;

            ctx.Pictures.AddRange(picturesAnisii);
            ctx.Pictures.AddRange(picturesPavla);
            ctx.Pictures.Add(pictSummer);

            ctx.ChildCards.AddRange(new List<ChildCardModel> { child1, child2, child3 });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}
