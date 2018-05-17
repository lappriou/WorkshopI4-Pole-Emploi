using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WorkshopI4.Core.Messages;
using WorkshopI4.Core.Extentions;
using WorkshopI4.Core.Services;
using WorkshopI4.Core.Models;
using System.Linq;

namespace WorkshopI4.Core.Helpers
{
    public class RabbitMQHelperActionPredicat : IRabbitMQHelperAction
    {
        public void ActionMessage(object message, IRabbitMQHelperAction newAction = null)
        {
            NewInteractionMessage mess;
            if (message is string)
            {
                 mess = JsonConvert.DeserializeObject<NewInteractionMessage>((string) message);
            }
            else if(message is NewInteractionMessage)
            {
                mess = (NewInteractionMessage) message;
            }
            else
            {
                mess = null;
            }

            if(mess != null)
            {
                var terminal = TerminalService.Get(mess.IDTerminal);
                if (terminal == null)
                {
                    terminal = new TerminalModel() { ID = mess.IDTerminal };
                    TerminalService.Insert(terminal);
                }

                var component = ComponentUIService.Get(mess.IDComponent);
                if(component == null)
                {
                    component = new ComponentUIModel()
                    {
                        ID = mess.IDComponent,
                        Type = mess.TypeComponentUI,
                    };

                    var page = PageService.Get(mess.IDPage);

                    if(page == null)
                    {
                        page = new PageModel();
                        page.ID = mess.IDPage;

                        PageService.Insert(page);
                    }

                    component.Page = page;
                    //page.Components.Add(component);
                }
                if(terminal.Interactions == null)
                {
                    terminal.Interactions = new List<InteractionModel>();
                }
                var interaction = new InteractionModel()
                {
                    ID = new Guid().ToString(),
                    Date = mess.Date,
                    Terminal = terminal,
                    TypeAction = mess.TypeAction,
                    IntervalTimeSecond = terminal.Interactions.Count() > 0 ? mess.Date.Subtract(terminal.Interactions.Last().Date).Seconds : 0
                };

                terminal.Interactions.Add(interaction);
                var oldStatut = terminal.Statut;
                terminal.Interactions.Add(interaction);
                terminal.UpdateStatut();
                if (newAction != null)
                {
                    var newMessage = new UpdateStatusTerminalMessage()
                    {
                        IdTerminal = terminal.ID,
                        Statut = terminal.Statut,
                    };

                    newAction.ActionMessage(newMessage);
                }
            }
            
        }
    }
}
