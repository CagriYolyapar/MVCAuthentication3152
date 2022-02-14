using MVCAuthentication_0.Models.Context;
using MVCAuthentication_0.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAuthentication_0.DesignPatterns.StrategyPattern
{

    /*
     
     CreateDatabaseIfNotExists => Bu class, eger yaratılmıs bir Database yok ise o zaman yaratılacak yapıların oldugu bir yöntemi bildirir....
     
     DropCreateDatabaseAlways => Bu class, her tetiklenmede veritabanını yok eder ve tekrar kurar...


    DropCreateDatabaseIfModelChanges => Sadece Model'de bir degişiklik oldugu zaman veritabanını silip bastan yaratma yöntemini uygulayan sınıflardır...Bu sınıfların her biri hangi veritabanında calısacagını bilmek zorundadırlar...

    Bu sınıfların icerisinde veritabanı yaratılırken bilgi de eklemenizi saglayan seed metodu bulunur... Default olarak bir görev yapmayan seed metodu virtual olarak tanımlandıgı icin Polymorphism kullanarak onu ezebilirsiniz ki böylece veritabanı yaratılırken eklemek istediginiz bilgileri koyarsınız...
     
     */




    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {

       

        protected override void Seed(MyContext context)
        {
            AppUser ap = new AppUser
            {
                UserName = "Cagri",
                Password = "cgr123",
                Role = Models.Enums.UserRole.Admin
            };

            AppUser ap2 = new AppUser
            {
                UserName = "Fatih",
                Password = "f123",
                Role = Models.Enums.UserRole.Member
            };
            
            context.AppUsers.Add(ap);
            context.AppUsers.Add(ap2);
            context.SaveChanges();
           
        }



    }
}