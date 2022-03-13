using EF.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public  class RepositoryBase
    {

        public DBContext instance;
        public RepositoryBase(DBContext db)
        {
            instance = db;
        }
    }


}
