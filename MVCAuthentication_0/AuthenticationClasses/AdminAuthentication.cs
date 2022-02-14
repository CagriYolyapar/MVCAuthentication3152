using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthentication_0.AuthenticationClasses
{
    /*
     
       AuthorizeAttribute gibi Attribute takısı ile biten sınıflar bir Controller'in veya Action'in üzerine attribute ile ekleme yapılmasını saglayan sınıflardır...Yani bu sınıftan miras alan sınıfınız artık bir Controller üzerine veya Action üzerine yazılıp daha onlar calısmadan işlem yapacaklardır...

    AuthorizeAttribute sınıfınız icerisinde virtual olarak tanımlanmıs AuthorizeCore isimli bir yapı barındırır....Bu yapıyı Polymorphism kullanarak override ederseniz daha ilgili yapıya ulasılmadan ne tarz bir kontrol yapacagınızı söyleyebilirsiniz...
     
     
     */

    public class AdminAuthentication:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["admin"] != null)
            {
                return true;
            }
            httpContext.Response.Redirect("/Auth/Login"); //sakın buradaki URL paterninin basına slash koymayı unutmayın yoksa gider normal paternin üzerinde bir daha Auth/Login  ....(https://44900/Home/Index/Auth/Login 
            return false;
        }
    }
}