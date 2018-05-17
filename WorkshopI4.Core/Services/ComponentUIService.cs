using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Services
{
    public static class ComponentUIService
    {
        private static List<ComponentUIModel> components = new List<ComponentUIModel>();

        public static List<ComponentUIModel> Get()
        {
            return components;
        }

        public static ComponentUIModel Get(string id)
        {
            return components.Where(p => p.ID == id).FirstOrDefault();
        }

        public static void Insert(ComponentUIModel component)
        {
            components.Add(component);
        }
    }
}
