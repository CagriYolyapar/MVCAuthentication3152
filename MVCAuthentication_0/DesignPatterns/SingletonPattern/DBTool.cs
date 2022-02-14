using MVCAuthentication_0.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthentication_0.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
        DBTool() { }

        static MyContext _dbInstance;

        public static MyContext DBInstance
        {
            get
            {
                if (_dbInstance == null) _dbInstance = new MyContext();
                return _dbInstance;
            }
        }
    }
}