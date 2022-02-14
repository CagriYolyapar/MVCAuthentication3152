using MVCAuthentication_0.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthentication_0.ViewModels
{
    public class AuthVM
    {
        public AppUser AppUser { get; set; }
        public List<AppUser> AppUsers { get; set; }

    }
}