using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopI4.Core.Models
{
    public abstract class ModelBase
    {
        public string ID { get; set; }
        public List<ParameterModel> Parameters { get; set; }
    }
}
