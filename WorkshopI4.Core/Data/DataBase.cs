using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkshopI4.Core.Data
{
    public abstract class DataBase
    {
        [Key]
        public string ID { get; set; }

        public List<ParameterData> Parameters { get; set; }
    }
}
