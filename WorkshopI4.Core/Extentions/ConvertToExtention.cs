using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopI4.Core.Data;
using WorkshopI4.Core.Messages;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Extentions
{
    public static class ConvertToExtention
    {
        public static ComponentUIData ToDTO(this ComponentUIModel model)
        {
            return new ComponentUIData()
            {
                ID = model.ID,
                Page = model.Page.ToDTO(),
                Parameters = (List<ParameterData>) model.Parameters.Select(p => p.ToDTO())
            };

        }

        public static ParameterData ToDTO(this ParameterModel model)
        {
            return new ParameterData()
            {
                Name = model.Name,
                Value = model.Value
            };
        }

        public static PageData ToDTO(this PageModel model)
        {
            return new PageData()
            {
                ID = model.ID,
                Components = model.Components.Select(p => p.ToDTO()),
                Parameters = (List<ParameterData>)model.Parameters.Select(p => p.ToDTO())
            };
        }

        public static TerminalData ToDTO(this TerminalModel model)
        {
            return new TerminalData()
            {
                ID = model.ID,
                Statut = model.Statut,
                Interactions = model.Interactions.Select(p => p.ToDTO()),
                Parameters = (List<ParameterData>)model.Parameters.Select(p => p.ToDTO())
            };
        }

        public static InteractionData ToDTO(this InteractionModel model)
        {
            return new InteractionData()
            {
                ID = model.ID,
                Time = model.IntervalTimeSecond,
                Date = model.Date,
                Terminal = model.Terminal.ToDTO(),
                TypeAction = model.TypeAction,
                Component = model.Component.ToDTO(),
                Individual = model.Individual.ToDTO(),
                Parameters = (List<ParameterData>)model.Parameters.Select(p => p.ToDTO())

            };
        }

        public static IndividualData ToDTO(this IndividualModel model)
        {
            return new IndividualData()
            {
                ID = model.ID,
                Parameters = (List<ParameterData>)model.Parameters.Select(p => p.ToDTO())
            };
        }

        public static IndividualModel ToModel(this IndividualData dto)
        {
            return new IndividualModel()
            {
                ID = dto.ID,
                Parameters = (List<ParameterModel>)dto.Parameters.Select(p => p.ToModel())
            };
        }



        public static ComponentUIModel ToModel(this ComponentUIData dto)
        {
            return new ComponentUIModel()
            {
                ID = dto.ID,
                Page = dto.Page.ToModel(),
                Parameters = (List<ParameterModel>)dto.Parameters.Select(p => p.ToModel())
            };

        }

        public static PageModel ToModel(this PageData dto)
        {
            return new PageModel()
            {
                ID = dto.ID,
                Components = dto.Components.Select(p => p.ToModel()).ToList(),
                Parameters = (List<ParameterModel>) dto.Parameters.Select(p => p.ToModel())
            };
        }

        public static ParameterModel ToModel(this ParameterData dto)
        {
            return new ParameterModel()
            {
                Name = dto.Name,
                Value = dto.Value
            };
        }

        public static TerminalModel ToModel(this TerminalData dto)
        {
            return new TerminalModel()
            {
                ID = dto.ID,
                Statut = dto.Statut,
                Interactions = dto.Interactions.Select(p => p.ToModel()).ToList(),
                Parameters = (List<ParameterModel>)dto.Parameters.Select(p => p.ToModel())
            };
        }

        public static InteractionModel ToModel(this InteractionData dto)
        {
            return new InteractionModel()
            {
                ID = dto.ID,
                IntervalTimeSecond = dto.Time,
                Terminal = dto.Terminal.ToModel(),
                TypeAction = dto.TypeAction,
                Component = dto.Component.ToModel(),
                Individual = dto.Individual.ToModel(),
                Date = dto.Date,
                Parameters = (List<ParameterModel>) dto.Parameters.Select(p => p.ToModel())
                
            };
        }

        public static string ToJson(this Object model)
        {
            return JsonConvert.SerializeObject(model);
        }

        public static Object ToObject(this string json, Type type)
        {
            return JsonConvert.DeserializeAnonymousType(json, type);
        }
    }

}
