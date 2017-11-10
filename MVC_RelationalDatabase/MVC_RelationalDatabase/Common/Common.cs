using MVC_RelationalDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.Common
{
    public static class Common
    {
        public static SchoolRepository SchoolRepository = new SchoolRepository();
    }
}