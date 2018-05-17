using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Data
{
    public class PageData : DataBase
    {
        [Key]
        public IEnumerable<ComponentUIData> Components { get; set; }
    }
}
