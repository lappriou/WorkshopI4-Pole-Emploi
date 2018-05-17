using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkshopI4.Core.Data
{
    public class ParameterData : DataBase
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
