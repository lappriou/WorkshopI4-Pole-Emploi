using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopI4.Core.Models
{
    public enum ETerminalStatut
    {
        Fluide,
        Incertain,
        Bloqué,
        SOS,
    }

    public enum ETypeAction
    {
        Click,
        Input
    }

    public enum ETypeUIElement
    {
        Button,
        Checkbox,
        Textbox
    }
}
