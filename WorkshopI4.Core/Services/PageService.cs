using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Services
{
    public static class PageService
    {
        private static List<PageModel> pages = new List<PageModel>();

        public static List<PageModel> Get()
        {
            return pages;
        }

        public static PageModel Get(string id)
        {
            return pages.Where(p => p.ID == id).FirstOrDefault();
        }

        public static void Insert(PageModel page)
        {
            pages.Add(page);
        }
    }
}
