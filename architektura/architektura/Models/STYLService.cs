using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using architektura.Models;


namespace architektura.Models
{
    public class STYLService
    {
        OperationDataContext dbContext = new OperationDataContext();


        public static List<STYL> getAllSTYLs()
        {
            using (var context = new OperationDataContext())
            {
                var query = from m in context.STYLs
                            select m;

                var stylList = query.ToList();

                return stylList;
            }
        }

        public static STYL getSTYLById(int idSTYL)
        {
            using (var context = new OperationDataContext())
            {
                var query = from m in context.STYLs
                            where m.idSTYL == idSTYL
                            select m;

                var styl = query.FirstOrDefault();

                return styl;
            }
        }

        public static int GetSizeSTYLList()
        {
            using (var context = new OperationDataContext())
            {
                int counter = 0;
                var query = from m in context.STYLs
                            select m;

                var stylList = query.ToList();

                foreach (STYL styl in stylList)
                {
                    counter++;
                }

                return counter;
            }
        }
        public static List<STYL> last3Styl()
        {
            using (var context = new OperationDataContext())
            {
                var query = from m in context.STYLs
                            orderby m.idSTYL descending
                            select m;

                var styls = query.Take(3).ToList();

                return styls;
            }
        }

    }
}