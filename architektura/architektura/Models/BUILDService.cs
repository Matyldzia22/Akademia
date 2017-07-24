using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using architektura.Models;

namespace architektura.Models
{
    public class BUILDService
    {
        public static List<BUILD> getAllBUILDs()
        {
            using (var context = new OperationDataContext())
            {
                var query = from m in context.BUILDs
                            select m;

                var buildList = query.ToList();

                return buildList;
            }
        }

        public static List<BUILD> getAllBUILDsFromSTYL(int idSTYL)
        {
            List<BUILD> stylBuildList = new List<BUILD>();
            using (var context = new OperationDataContext())
            {
                foreach (var buildList in getAllBUILDs())
                {
                    if (buildList.idSTYL == idSTYL)
                    {

                        stylBuildList.Add(buildList);
                    }
                }

                return stylBuildList;
            }
        }
        public static int GetSizeBUILDList()
        {
            using (var context = new OperationDataContext())
            {
                int counter = 0;
                var query = from m in context.BUILDs
                            select m;

                var buildList = query.ToList();

                foreach (BUILD build in buildList)
                {
                    counter++;
                }

                return counter;
            }
        }
    }
}